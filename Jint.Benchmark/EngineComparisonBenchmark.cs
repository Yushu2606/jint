using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using Okojo.Bytecode;
using Okojo.Compiler;
using Okojo.Parsing;
using Okojo.Runtime;

namespace Jint.Benchmark;

[RankColumn]
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
[HideColumns("Error", "Gen0", "Gen1", "Gen2")]
[BenchmarkCategory("EngineComparison")]
public class EngineComparisonBenchmark
{
    private static readonly Dictionary<string, Prepared<Script>> _parsedScripts = new();
    private static readonly Dictionary<string, (JsRuntime, JsScript)> _compiledScripts = new();

    private static readonly Dictionary<string, string> _files = new()
    {
        { "array-stress", null },
        { "evaluation", null },
        { "evaluation-modern", null },
        { "linq-js", null },
        { "minimal", null },
        { "stopwatch", null },
        { "stopwatch-modern", null },
        { "dromaeo-3d-cube", null },
        { "dromaeo-3d-cube-modern", null },
        { "dromaeo-core-eval", null },
        { "dromaeo-core-eval-modern", null },
        { "dromaeo-object-array", null },
        { "dromaeo-object-array-modern", null },
        { "dromaeo-object-regexp", null },
        { "dromaeo-object-regexp-modern", null },
        { "dromaeo-object-string", null },
        { "dromaeo-object-string-modern", null },
        { "dromaeo-string-base64", null },
        { "dromaeo-string-base64-modern", null },
    };

    private static readonly string _dromaeoHelpers = @"
        var startTest = function () { };
        var test = function (name, fn) { fn(); };
        var endTest = function () { };
        var prep = function (fn) { fn(); };";

    [GlobalSetup]
    public void Setup()
    {
        foreach (var fileName in _files.Keys.ToList())
        {
            var script = File.ReadAllText($"Scripts/{fileName}.js");
            if (fileName.Contains("dromaeo"))
            {
                script = _dromaeoHelpers + Environment.NewLine + Environment.NewLine + script;
            }
            _files[fileName] = script;
            _parsedScripts[fileName] = Engine.PrepareScript(script, strict: true);
            var program = JavaScriptParser.ParseScript(script);
            var engine = JsRuntime.Create();
            var realm = engine.MainRealm;
            var okojoScript = JsCompiler.Compile(realm, program);
            _compiledScripts[fileName] = (engine, okojoScript);
        }
    }

    [ParamsSource(nameof(FileNames))]
    public string FileName { get; set; }

    public IEnumerable<string> FileNames()
    {
        return _files.Select(entry => entry.Key);
    }

    [Benchmark]
    public void Jint()
    {
        var engine = new Engine(static options => options.Strict());
        engine.Execute(_files[FileName]);
    }

    [Benchmark]
    public void Jint_ParsedScript()
    {
        var engine = new Engine(static options => options.Strict());
        engine.Execute(_parsedScripts[FileName]);
    }

    [Benchmark]
    public void NiLJS()
    {
        var engine = new NiL.JS.Core.Context(strict: true);
        engine.Eval(_files[FileName]);
    }

    [Benchmark]
    public void NiLJS_Model()
    {
        var engine = new NiL.JS.Module(_files[FileName]);
        engine.Run();
    }

    [Benchmark]
    public void YantraJS()
    {
        var engine = new YantraJS.Core.JSContext();
        // By default YantraJS is strict mode only, in strict mode
        // we need to pass `this` explicitly in global context
        // if script is expecting global context as `this`
        engine.Eval(_files[FileName], null, engine);
    }

    [Benchmark]
    public void Okojo()
    {
        var engine = JsRuntime.Create();
        var realm = engine.MainRealm;
        realm.Execute(_files[FileName]);
    }

    [Benchmark]
    public void Okojo_CompiledScript()
    {
        var (engine, script) = _compiledScripts[FileName];
        var realm = engine.MainRealm;
        realm.Execute(script);
    }
}
