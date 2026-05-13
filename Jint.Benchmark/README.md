To run tests comparing engines, use:

```
dotnet run -c Release --allCategories EngineComparison
```

## Engine comparison results 

* tests are run in global engine strict mode, as YantraJS always uses strict mode which improves performance
* `Jint` and `Jint_ParsedScript` shows the difference between always parsing the script source file and reusing parsed `Script` instance.

Last updated 2026-05-10

* Jint 4.9.0
* Jurassic 3.2.9
* NiL.JS 2.6.1722
* YantraJS.Core 1.2.344

```

BenchmarkDotNet v0.15.8, Linux Ubuntu 24.04.3 LTS (Noble Numbat)
Neoverse-N2, 4 physical cores
.NET SDK 10.0.300
  [Host]     : .NET 10.0.8 (10.0.8, 10.0.826.23019), Arm64 RyuJIT armv8.0-a
  DefaultJob : .NET 10.0.8 (10.0.8, 10.0.826.23019), Arm64 RyuJIT armv8.0-a


```
| Method               | FileName             | Mean                | StdDev              | Median              | Rank | Allocated     |
|--------------------- |--------------------- |--------------------:|--------------------:|--------------------:|-----:|--------------:|
| YantraJS             | array-stress         |      5,906,946.8 ns |        22,546.59 ns |      5,902,826.3 ns |    1 |    29432589 B |
| Okojo_CompiledScript | array-stress         |      6,535,673.0 ns |        24,328.87 ns |      6,550,114.7 ns |    2 |     1443352 B |
| Jint                 | array-stress         |      6,617,924.3 ns |         6,127.62 ns |      6,616,602.5 ns |    2 |     1987208 B |
| Jint_ParsedScript    | array-stress         |      6,628,168.4 ns |         4,176.22 ns |      6,628,678.4 ns |    2 |     1957728 B |
| NiLJS                | array-stress         |      7,490,316.1 ns |         6,841.50 ns |      7,494,000.1 ns |    3 |     4629696 B |
| NiLJS_Model          | array-stress         |      7,526,699.8 ns |         5,083.32 ns |      7,527,539.3 ns |    3 |     4630728 B |
| Okojo                | array-stress         |      7,693,687.2 ns |        24,472.67 ns |      7,694,623.9 ns |    3 |     2760951 B |
|                      |                      |                     |                     |                     |      |               |
| YantraJS             | dromaeo-3d-cube      |      4,741,947.6 ns |        15,647.11 ns |      4,739,332.6 ns |    1 |     9303019 B |
| Okojo_CompiledScript | dromaeo-3d-cube      |      6,185,484.6 ns |         2,733.32 ns |      6,185,488.3 ns |    2 |      771744 B |
| Okojo                | dromaeo-3d-cube      |      7,912,320.4 ns |        26,127.79 ns |      7,916,882.2 ns |    3 |     2521927 B |
| NiLJS_Model          | dromaeo-3d-cube      |      9,048,154.3 ns |        19,641.84 ns |      9,042,065.2 ns |    4 |     5011560 B |
| NiLJS                | dromaeo-3d-cube      |      9,244,501.8 ns |        11,340.07 ns |      9,245,415.1 ns |    4 |     5011536 B |
| Jint_ParsedScript    | dromaeo-3d-cube      |     20,706,886.4 ns |        17,450.98 ns |     20,704,769.9 ns |    5 |     6218312 B |
| Jint                 | dromaeo-3d-cube      |     21,052,700.9 ns |        31,418.96 ns |     21,051,877.8 ns |    5 |     6528200 B |
|                      |                      |                     |                     |                     |      |               |
| YantraJS             | droma(...)odern [22] |      4,720,711.6 ns |         8,107.37 ns |      4,722,188.4 ns |    1 |     9178262 B |
| Okojo_CompiledScript | droma(...)odern [22] |      6,541,710.5 ns |         2,344.34 ns |      6,541,840.5 ns |    2 |      724848 B |
| Okojo                | droma(...)odern [22] |      8,264,854.0 ns |        12,077.74 ns |      8,261,249.5 ns |    3 |     2553975 B |
| NiLJS                | droma(...)odern [22] |     10,787,524.9 ns |        15,060.55 ns |     10,785,453.3 ns |    4 |     6112016 B |
| NiLJS_Model          | droma(...)odern [22] |     10,926,010.0 ns |        19,816.54 ns |     10,928,955.5 ns |    4 |     6112040 B |
| Jint                 | droma(...)odern [22] |     21,322,671.1 ns |        10,394.78 ns |     21,322,030.5 ns |    5 |     6527120 B |
| Jint_ParsedScript    | droma(...)odern [22] |     21,736,032.1 ns |        14,672.49 ns |     21,732,888.2 ns |    5 |     6217432 B |
|                      |                      |                     |                     |                     |      |               |
| NiLJS                | dromaeo-core-eval    |      1,917,592.0 ns |         9,257.45 ns |      1,917,338.8 ns |    1 |     1614824 B |
| NiLJS_Model          | dromaeo-core-eval    |      2,144,681.2 ns |         1,443.61 ns |      2,144,536.5 ns |    2 |     1614232 B |
| Jint                 | dromaeo-core-eval    |      4,003,666.9 ns |         2,717.53 ns |      4,003,838.5 ns |    3 |     1377424 B |
| Okojo_CompiledScript | dromaeo-core-eval    |      4,056,581.8 ns |         5,543.42 ns |      4,056,614.0 ns |    3 |     3363633 B |
| Jint_ParsedScript    | dromaeo-core-eval    |      4,078,548.2 ns |         2,777.80 ns |      4,077,794.3 ns |    3 |     1356568 B |
| Okojo                | dromaeo-core-eval    |      6,165,610.5 ns |        25,895.26 ns |      6,170,904.2 ns |    4 |     4730565 B |
| YantraJS             | dromaeo-core-eval    |      7,507,854.4 ns |        36,289.31 ns |      7,512,791.9 ns |    5 |    38426513 B |
|                      |                      |                     |                     |                     |      |               |
| NiLJS                | droma(...)odern [24] |      2,107,495.6 ns |         3,102.03 ns |      2,106,767.2 ns |    1 |     1613648 B |
| NiLJS_Model          | droma(...)odern [24] |      2,156,800.7 ns |         2,137.68 ns |      2,156,528.8 ns |    2 |     1613464 B |
| Jint_ParsedScript    | droma(...)odern [24] |      3,879,667.9 ns |         1,826.40 ns |      3,879,799.6 ns |    3 |     1356232 B |
| Jint                 | droma(...)odern [24] |      4,038,064.5 ns |         2,517.25 ns |      4,038,577.9 ns |    4 |     1376344 B |
| Okojo_CompiledScript | droma(...)odern [24] |      4,102,444.7 ns |         7,341.39 ns |      4,101,701.6 ns |    4 |     3363857 B |
| Okojo                | droma(...)odern [24] |      6,368,548.2 ns |        52,563.79 ns |      6,376,830.3 ns |    5 |     4736261 B |
| YantraJS             | droma(...)odern [24] |      7,516,764.6 ns |        24,414.02 ns |      7,508,018.0 ns |    6 |    38426641 B |
|                      |                      |                     |                     |                     |      |               |
| Jint                 | dromaeo-object-array |     28,533,731.5 ns |        82,072.04 ns |     28,523,976.7 ns |    1 |    10764752 B |
| Jint_ParsedScript    | dromaeo-object-array |     29,467,684.8 ns |       154,287.39 ns |     29,477,949.6 ns |    2 |    10715360 B |
| Okojo_CompiledScript | dromaeo-object-array |     45,662,616.2 ns |       210,580.39 ns |     45,762,394.8 ns |    3 |     5771320 B |
| Okojo                | dromaeo-object-array |     47,156,053.3 ns |        40,782.96 ns |     47,151,197.4 ns |    4 |     7165220 B |
| NiLJS                | dromaeo-object-array |     75,472,119.6 ns |        39,806.58 ns |     75,473,205.4 ns |    5 |    18290624 B |
| NiLJS_Model          | dromaeo-object-array |     75,693,543.6 ns |        35,129.79 ns |     75,694,721.2 ns |    5 |    18290920 B |
| YantraJS             | dromaeo-object-array |     96,436,469.9 ns |       866,154.75 ns |     96,712,749.5 ns |    6 |   394483073 B |
|                      |                      |                     |                     |                     |      |               |
| Jint                 | droma(...)odern [27] |     29,332,899.4 ns |        63,125.97 ns |     29,339,200.4 ns |    1 |    10765448 B |
| Jint_ParsedScript    | droma(...)odern [27] |     30,572,194.7 ns |       154,535.22 ns |     30,594,864.5 ns |    2 |    10717040 B |
| Okojo_CompiledScript | droma(...)odern [27] |     48,848,649.7 ns |       186,280.03 ns |     48,980,439.6 ns |    3 |     5772160 B |
| Okojo                | droma(...)odern [27] |     50,606,066.4 ns |        74,296.61 ns |     50,569,652.5 ns |    4 |     7180198 B |
| NiLJS_Model          | droma(...)odern [27] |     76,013,859.9 ns |        23,489.50 ns |     76,013,647.1 ns |    5 |    18291944 B |
| NiLJS                | droma(...)odern [27] |     76,590,368.8 ns |        67,783.01 ns |     76,574,818.4 ns |    5 |    18291648 B |
| YantraJS             | droma(...)odern [27] |     84,961,663.6 ns |       680,442.55 ns |     84,962,763.3 ns |    6 |   398364451 B |
|                      |                      |                     |                     |                     |      |               |
| Jint_ParsedScript    | droma(...)egexp [21] |    142,700,358.7 ns |     1,504,688.04 ns |    142,455,083.0 ns |    1 |   167138424 B |
| Jint                 | droma(...)egexp [21] |    199,423,919.8 ns |     2,440,583.26 ns |    199,484,512.0 ns |    2 |   166709400 B |
| NiLJS                | droma(...)egexp [21] |    446,829,741.5 ns |     5,899,498.20 ns |    449,329,348.5 ns |    3 |   787000896 B |
| NiLJS_Model          | droma(...)egexp [21] |    465,124,404.7 ns |     4,938,682.63 ns |    464,847,573.0 ns |    3 |   786478696 B |
| Okojo_CompiledScript | droma(...)egexp [21] |  2,860,228,343.7 ns |    11,756,164.51 ns |  2,864,102,511.0 ns |    4 |  1840628440 B |
| Okojo                | droma(...)egexp [21] |  2,873,646,478.7 ns |     8,043,489.72 ns |  2,871,976,591.5 ns |    4 |  1843978240 B |
| YantraJS             | droma(...)egexp [21] | 25,042,689,057.1 ns | 2,015,566,522.83 ns | 24,999,328,493.5 ns |    5 | 33148371632 B |
|                      |                      |                     |                     |                     |      |               |
| Jint_ParsedScript    | droma(...)odern [28] |    144,052,418.2 ns |     1,014,994.18 ns |    144,192,132.0 ns |    1 |   166842848 B |
| Jint                 | droma(...)odern [28] |    201,381,162.7 ns |     2,031,269.64 ns |    200,738,472.0 ns |    2 |   173072232 B |
| NiLJS                | droma(...)odern [28] |    455,736,386.0 ns |     5,619,234.35 ns |    454,331,611.0 ns |    3 |   784643704 B |
| NiLJS_Model          | droma(...)odern [28] |    462,748,936.5 ns |     5,939,312.18 ns |    463,287,645.0 ns |    3 |   785380136 B |
| Okojo_CompiledScript | droma(...)odern [28] |  2,924,353,134.2 ns |    10,174,027.13 ns |  2,924,975,772.0 ns |    4 |  1840888336 B |
| Okojo                | droma(...)odern [28] |  2,989,301,250.5 ns |     7,809,939.78 ns |  2,987,751,340.0 ns |    4 |  1843416760 B |
| YantraJS             | droma(...)odern [28] | 25,531,320,717.9 ns | 1,932,380,799.88 ns | 25,574,122,372.5 ns |    5 | 33168525152 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | droma(...)tring [21] |     64,582,817.1 ns |       281,645.92 ns |     64,488,075.9 ns |    1 |    32751367 B |
| Okojo                | droma(...)tring [21] |     67,026,024.4 ns |       131,510.05 ns |     67,073,208.0 ns |    2 |    34279083 B |
| Jint                 | droma(...)tring [21] |    373,866,541.5 ns |    22,284,532.79 ns |    366,751,635.0 ns |    3 |  1335492144 B |
| Jint_ParsedScript    | droma(...)tring [21] |    374,491,089.7 ns |    29,659,687.36 ns |    372,396,457.0 ns |    3 |  1335174040 B |
| NiLJS_Model          | droma(...)tring [21] |    527,332,060.5 ns |     1,815,419.83 ns |    527,816,904.0 ns |    4 |  1387422536 B |
| NiLJS                | droma(...)tring [21] |    531,913,579.9 ns |     2,434,284.55 ns |    531,193,905.5 ns |    4 |  1387130760 B |
| YantraJS             | droma(...)tring [21] |    590,346,643.2 ns |   112,052,617.46 ns |    541,018,898.0 ns |    4 |  3260657928 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | droma(...)odern [28] |     66,397,741.3 ns |       243,286.96 ns |     66,406,426.5 ns |    1 |    32793686 B |
| Okojo                | droma(...)odern [28] |     69,172,386.6 ns |       178,624.09 ns |     69,215,845.8 ns |    2 |    34320359 B |
| Jint                 | droma(...)odern [28] |    362,231,795.1 ns |     3,284,187.77 ns |    362,926,796.0 ns |    3 |  1335386776 B |
| Jint_ParsedScript    | droma(...)odern [28] |    376,314,551.3 ns |    25,525,270.33 ns |    378,206,470.5 ns |    3 |  1335052488 B |
| NiLJS                | droma(...)odern [28] |    533,672,750.3 ns |     2,283,276.57 ns |    533,538,063.0 ns |    4 |  1387302256 B |
| NiLJS_Model          | droma(...)odern [28] |    533,722,890.6 ns |     2,246,368.55 ns |    533,848,830.5 ns |    4 |  1387228496 B |
| YantraJS             | droma(...)odern [28] |    557,994,976.2 ns |    40,053,355.18 ns |    550,522,368.5 ns |    4 |  3307610912 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | droma(...)ase64 [21] |     32,016,285.9 ns |        24,773.84 ns |     32,019,014.5 ns |    1 |    43390720 B |
| Okojo                | droma(...)ase64 [21] |     34,418,602.2 ns |       104,552.67 ns |     34,445,376.2 ns |    2 |    44854691 B |
| NiLJS_Model          | droma(...)ase64 [21] |     39,705,031.1 ns |       172,235.62 ns |     39,691,725.6 ns |    3 |    20058488 B |
| NiLJS                | droma(...)ase64 [21] |     40,374,510.0 ns |        79,004.60 ns |     40,373,542.6 ns |    3 |    20057968 B |
| Jint_ParsedScript    | droma(...)ase64 [21] |     42,628,102.8 ns |        55,246.56 ns |     42,614,149.9 ns |    4 |     3764016 B |
| Jint                 | droma(...)ase64 [21] |     42,930,164.2 ns |       130,673.64 ns |     42,945,795.0 ns |    4 |     3864280 B |
| YantraJS             | droma(...)ase64 [21] |     64,962,135.4 ns |       424,807.97 ns |     65,051,423.8 ns |    5 |   788229962 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | droma(...)odern [28] |     33,483,342.5 ns |        21,945.41 ns |     33,491,764.4 ns |    1 |    43390992 B |
| Okojo                | droma(...)odern [28] |     35,413,335.8 ns |        78,133.23 ns |     35,387,528.9 ns |    2 |    44869807 B |
| Jint                 | droma(...)odern [28] |     47,166,173.5 ns |        15,850.77 ns |     47,165,404.9 ns |    3 |     3864656 B |
| Jint_ParsedScript    | droma(...)odern [28] |     48,498,850.7 ns |        21,705.45 ns |     48,500,418.2 ns |    4 |     3764096 B |
| NiLJS_Model          | droma(...)odern [28] |     51,758,108.9 ns |       339,062.48 ns |     51,803,931.8 ns |    5 |    32112584 B |
| NiLJS                | droma(...)odern [28] |     52,120,901.3 ns |       320,508.27 ns |     52,103,161.1 ns |    5 |    32112064 B |
| YantraJS             | droma(...)odern [28] |     65,143,783.5 ns |       335,898.98 ns |     65,188,801.2 ns |    6 |   789475210 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | evaluation           |          1,853.0 ns |             0.95 ns |          1,853.2 ns |    1 |         728 B |
| Jint_ParsedScript    | evaluation           |          8,051.6 ns |             8.98 ns |          8,049.7 ns |    2 |       24048 B |
| Jint                 | evaluation           |         20,002.2 ns |            32.69 ns |         19,994.6 ns |    3 |       34944 B |
| NiLJS_Model          | evaluation           |         33,259.8 ns |            38.05 ns |         33,264.3 ns |    4 |       22920 B |
| NiLJS                | evaluation           |         33,366.8 ns |            42.23 ns |         33,366.2 ns |    4 |       22896 B |
| YantraJS             | evaluation           |        268,836.6 ns |           667.53 ns |        268,583.7 ns |    5 |     1216104 B |
| Okojo                | evaluation           |        885,657.0 ns |        20,180.80 ns |        885,680.5 ns |    6 |     1316746 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | evaluation-modern    |          1,845.4 ns |             1.10 ns |          1,845.4 ns |    1 |         832 B |
| Jint_ParsedScript    | evaluation-modern    |          8,244.4 ns |            12.51 ns |          8,244.1 ns |    2 |       23488 B |
| Jint                 | evaluation-modern    |         20,041.3 ns |            33.94 ns |         20,035.0 ns |    3 |       34872 B |
| NiLJS_Model          | evaluation-modern    |         33,834.9 ns |            35.89 ns |         33,840.1 ns |    4 |       22912 B |
| NiLJS                | evaluation-modern    |         33,836.0 ns |            45.08 ns |         33,851.2 ns |    4 |       22888 B |
| YantraJS             | evaluation-modern    |        275,420.4 ns |         2,934.17 ns |        274,033.4 ns |    5 |     1216080 B |
| Okojo                | evaluation-modern    |        905,136.0 ns |        18,481.12 ns |        900,081.0 ns |    6 |     1320918 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | linq-js              |         48,754.3 ns |            52.48 ns |         48,762.7 ns |    1 |       95024 B |
| Jint_ParsedScript    | linq-js              |         99,509.0 ns |           145.37 ns |         99,476.9 ns |    2 |      191504 B |
| YantraJS             | linq-js              |        549,017.9 ns |         1,271.17 ns |        548,677.9 ns |    3 |     1775106 B |
| Jint                 | linq-js              |      1,566,233.9 ns |         6,745.98 ns |      1,568,166.2 ns |    4 |     1317080 B |
| NiLJS_Model          | linq-js              |      5,197,718.6 ns |        38,992.59 ns |      5,203,077.7 ns |    5 |     2805240 B |
| NiLJS                | linq-js              |      5,310,008.6 ns |        37,620.75 ns |      5,328,850.7 ns |    5 |     2805208 B |
| Okojo                | linq-js              |     11,656,278.0 ns |        29,123.42 ns |     11,649,402.9 ns |    6 |     6907698 B |
|                      |                      |                     |                     |                     |      |               |
| Okojo_CompiledScript | minimal              |            376.6 ns |             0.10 ns |            376.7 ns |    1 |         192 B |
| Jint_ParsedScript    | minimal              |          3,075.0 ns |             6.78 ns |          3,075.2 ns |    2 |       15832 B |
| NiLJS                | minimal              |          3,732.2 ns |             2.91 ns |          3,732.7 ns |    3 |        4616 B |
| NiLJS_Model          | minimal              |          3,859.1 ns |             5.05 ns |          3,857.9 ns |    4 |        4880 B |
| Jint                 | minimal              |          4,625.5 ns |             6.80 ns |          4,626.1 ns |    5 |       17792 B |
| YantraJS             | minimal              |        262,688.1 ns |           560.29 ns |        262,663.2 ns |    6 |     1207311 B |
| Okojo                | minimal              |        792,437.5 ns |        16,405.19 ns |        795,138.7 ns |    7 |     1278376 B |
|                      |                      |                     |                     |                     |      |               |
| YantraJS             | stopwatch            |    100,806,999.9 ns |       164,062.89 ns |    100,790,807.8 ns |    1 |   253519053 B |
| Okojo                | stopwatch            |    167,071,046.2 ns |     2,445,006.09 ns |    168,362,981.3 ns |    2 |    21976261 B |
| Okojo_CompiledScript | stopwatch            |    167,771,334.0 ns |       905,283.59 ns |    168,140,596.2 ns |    2 |    20578464 B |
| NiLJS                | stopwatch            |    193,673,229.5 ns |       642,296.32 ns |    193,344,674.7 ns |    3 |    97153528 B |
| NiLJS_Model          | stopwatch            |    195,198,951.4 ns |       367,353.46 ns |    195,314,972.7 ns |    3 |    97154064 B |
| Jint                 | stopwatch            |    307,712,955.2 ns |       334,054.67 ns |    307,792,830.5 ns |    4 |    40365264 B |
| Jint_ParsedScript    | stopwatch            |    312,640,178.9 ns |       541,368.37 ns |    312,607,136.5 ns |    4 |    40332672 B |
|                      |                      |                     |                     |                     |      |               |
| YantraJS             | stopwatch-modern     |    105,981,127.9 ns |       249,608.45 ns |    105,947,458.2 ns |    1 |   272338141 B |
| Okojo_CompiledScript | stopwatch-modern     |    171,177,395.8 ns |       505,547.70 ns |    171,399,511.7 ns |    2 |    20578568 B |
| Okojo                | stopwatch-modern     |    171,351,455.1 ns |     1,678,386.91 ns |    172,256,105.7 ns |    2 |    21979021 B |
| Jint                 | stopwatch-modern     |    351,669,485.9 ns |       816,932.53 ns |    351,313,752.0 ns |    3 |    40586688 B |
| NiLJS_Model          | stopwatch-modern     |    357,939,362.9 ns |       579,703.24 ns |    357,839,063.0 ns |    3 |   332291328 B |
| Jint_ParsedScript    | stopwatch-modern     |    362,870,396.0 ns |     1,517,881.24 ns |    362,625,337.0 ns |    3 |    40553512 B |
| NiLJS                | stopwatch-modern     |    373,376,747.8 ns |       625,839.31 ns |    373,233,084.5 ns |    4 |   332291064 B |
