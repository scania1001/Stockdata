﻿using Stockdata.Model;

using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Threading;

namespace Stockdata
{
    public class stock
    {
        public int SID { get; set; } //股票代碼
        public DateTime? Sdate { get; set; }//股東會日期
        public DateTime? ExRdate { get; set; }//除息日期
        public Decimal? ExR { get; set; }//除息價格
        public DateTime? ExDdate { get; set; }//除權日期
        public Decimal? ExD { get; set; }//除權價格
        public DateTime? Cashdate { get; set; }//現金股利發放日
        public Decimal? CashDividend { get; set; }//現金股利
        public Decimal? StockDividendRE { get; set; }//盈餘配股
        public Decimal? StockDividendCR { get; set; }//股利合計
    }
    class Program
    {

        static void Main(string[] args)
        {
                string[] AllStock = {"1101",
"1102",
"1103",
"1104",
"1108",
"1109",
"1110",
"1201",
"1203",
"1210",
"1213",
"1215",
"1216",
"1217",
"1218",
"1219",
"1220",
"1225",
"1227",
"1229",
"1231",
"1232",
"1233",
"1234",
"1235",
"1236",
"1256",
"1258",
"1259",
"1262",
"1264",
"1301",
"1303",
"1304",
"1305",
"1307",
"1308",
"1309",
"1310",
"1312",
"1313",
"1314",
"1315",
"1316",
"1319",
"1321",
"1323",
"1324",
"1325",
"1326",
"1333",
"1336",
"1337",
"1338",
"1339",
"1340",
"1402",
"1409",
"1410",
"1413",
"1414",
"1416",
"1417",
"1418",
"1419",
"1423",
"1432",
"1434",
"1435",
"1436",
"1437",
"1438",
"1439",
"1440",
"1441",
"1442",
"1443",
"1444",
"1445",
"1446",
"1447",
"1449",
"1451",
"1452",
"1453",
"1454",
"1455",
"1456",
"1457",
"1459",
"1460",
"1463",
"1464",
"1465",
"1466",
"1467",
"1468",
"1469",
"1470",
"1471",
"1472",
"1473",
"1474",
"1475",
"1476",
"1477",
"1503",
"1504",
"1506",
"1507",
"1512",
"1513",
"1514",
"1515",
"1516",
"1517",
"1519",
"1521",
"1522",
"1524",
"1525",
"1526",
"1527",
"1528",
"1529",
"1530",
"1531",
"1532",
"1533",
"1535",
"1536",
"1537",
"1538",
"1539",
"1540",
"1541",
"1558",
"1560",
"1565",
"1566",
"1568",
"1569",
"1570",
"1580",
"1582",
"1583",
"1584",
"1586",
"1589",
"1590",
"1591",
"1592",
"1593",
"1595",
"1597",
"1598",
"1599",
"1603",
"1604",
"1605",
"1608",
"1609",
"1611",
"1612",
"1613",
"1614",
"1615",
"1616",
"1617",
"1618",
"1626",
"1701",
"1702",
"1704",
"1707",
"1708",
"1709",
"1710",
"1711",
"1712",
"1713",
"1714",
"1715",
"1717",
"1718",
"1720",
"1721",
"1722",
"1723",
"1724",
"1725",
"1726",
"1727",
"1729",
"1730",
"1731",
"1732",
"1733",
"1734",
"1735",
"1736",
"1737",
"1742",
"1752",
"1762",
"1773",
"1776",
"1777",
"1781",
"1783",
"1784",
"1785",
"1786",
"1787",
"1788",
"1789",
"1795",
"1799",
"1802",
"1805",
"1806",
"1808",
"1809",
"1810",
"1813",
"1815",
"1817",
"1902",
"1903",
"1904",
"1905",
"1906",
"1907",
"1909",
"2002",
"2006",
"2007",
"2008",
"2009",
"2010",
"2012",
"2013",
"2014",
"2015",
"2017",
"2020",
"2022",
"2023",
"2024",
"2025",
"2027",
"2028",
"2029",
"2030",
"2031",
"2032",
"2033",
"2034",
"2035",
"2038",
"2049",
"2059",
"2061",
"2062",
"2063",
"2064",
"2065",
"2066",
"2067",
"2069",
"2101",
"2102",
"2103",
"2104",
"2105",
"2106",
"2107",
"2108",
"2109",
"2114",
"2115",
"2201",
"2204",
"2206",
"2207",
"2208",
"2221",
"2227",
"2228",
"2230",
"2231",
"2233",
"2235",
"2236",
"2239",
"2301",
"2302",
"2303",
"2305",
"2308",
"2311",
"2312",
"2313",
"2314",
"2316",
"2317",
"2321",
"2323",
"2324",
"2325",
"2327",
"2328",
"2329",
"2330",
"2331",
"2332",
"2337",
"2338",
"2340",
"2342",
"2344",
"2345",
"2347",
"2348",
"2349",
"2351",
"2352",
"2353",
"2354",
"2355",
"2356",
"2357",
"2358",
"2359",
"2360",
"2362",
"2363",
"2364",
"2365",
"2367",
"2368",
"2369",
"2371",
"2373",
"2374",
"2375",
"2376",
"2377",
"2379",
"2380",
"2382",
"2383",
"2385",
"2387",
"2388",
"2390",
"2392",
"2393",
"2395",
"2397",
"2399",
"2401",
"2402",
"2404",
"2405",
"2406",
"2408",
"2409",
"2412",
"2413",
"2414",
"2415",
"2417",
"2419",
"2420",
"2421",
"2423",
"2424",
"2425",
"2426",
"2427",
"2428",
"2429",
"2430",
"2431",
"2433",
"2434",
"2436",
"2437",
"2438",
"2439",
"2440",
"2441",
"2442",
"2443",
"2444",
"2448",
"2449",
"2450",
"2451",
"2453",
"2454",
"2455",
"2456",
"2457",
"2458",
"2459",
"2460",
"2461",
"2462",
"2464",
"2465",
"2466",
"2467",
"2468",
"2471",
"2472",
"2474",
"2475",
"2476",
"2477",
"2478",
"2480",
"2481",
"2482",
"2483",
"2484",
"2485",
"2486",
"2488",
"2489",
"2491",
"2492",
"2493",
"2495",
"2496",
"2497",
"2498",
"2499",
"2501",
"2504",
"2505",
"2506",
"2509",
"2511",
"2514",
"2515",
"2516",
"2520",
"2524",
"2527",
"2528",
"2530",
"2534",
"2535",
"2536",
"2537",
"2538",
"2539",
"2540",
"2542",
"2543",
"2545",
"2546",
"2547",
"2548",
"2596",
"2597",
"2601",
"2603",
"2605",
"2606",
"2607",
"2608",
"2609",
"2610",
"2611",
"2612",
"2613",
"2614",
"2615",
"2616",
"2617",
"2618",
"2633",
"2634",
"2636",
"2637",
"2640",
"2641",
"2642",
"2643",
"2701",
"2702",
"2704",
"2705",
"2706",
"2707",
"2712",
"2718",
"2719",
"2722",
"2723",
"2724",
"2726",
"2727",
"2729",
"2731",
"2732",
"2734",
"2736",
"2739",
"2740",
"2748",
"2801",
"2809",
"2812",
"2816",
"2820",
"2823",
"2832",
"2834",
"2836",
"2838",
"2841",
"2845",
"2849",
"2850",
"2851",
"2852",
"2855",
"2856",
"2867",
"2880",
"2881",
"2882",
"2883",
"2884",
"2885",
"2886",
"2887",
"2888",
"2889",
"2890",
"2891",
"2892",
"2897",
"2901",
"2903",
"2904",
"2905",
"2906",
"2908",
"2910",
"2911",
"2912",
"2913",
"2915",
"2916",
"2923",
"2924",
"2926",
"2928",
"2929",
"2936",
"3002",
"3003",
"3004",
"3005",
"3006",
"3008",
"3010",
"3011",
"3013",
"3014",
"3015",
"3016",
"3017",
"3018",
"3019",
"3021",
"3022",
"3023",
"3024",
"3025",
"3026",
"3027",
"3028",
"3029",
"3030",
"3031",
"3032",
"3033",
"3034",
"3035",
"3036",
"3037",
"3038",
"3040",
"3041",
"3042",
"3043",
"3044",
"3045",
"3046",
"3047",
"3048",
"3049",
"3050",
"3051",
"3052",
"3054",
"3055",
"3056",
"3057",
"3058",
"3059",
"3060",
"3062",
"3064",
"3066",
"3067",
"3068",
"3071",
"3073",
"3078",
"3081",
"3083",
"3085",
"3086",
"3088",
"3089",
"3090",
"3092",
"3093",
"3094",
"3095",
"3105",
"3114",
"3115",
"3118",
"3122",
"3128",
"3130",
"3131",
"3141",
"3144",
"3149",
"3152",
"3162",
"3163",
"3164",
"3167",
"3169",
"3171",
"3176",
"3188",
"3189",
"3191",
"3202",
"3205",
"3206",
"3207",
"3209",
"3211",
"3213",
"3217",
"3218",
"3219",
"3221",
"3224",
"3226",
"3227",
"3228",
"3229",
"3230",
"3231",
"3232",
"3234",
"3236",
"3252",
"3257",
"3259",
"3260",
"3264",
"3265",
"3266",
"3268",
"3272",
"3276",
"3284",
"3285",
"3287",
"3288",
"3289",
"3290",
"3293",
"3294",
"3296",
"3297",
"3299",
"3303",
"3305",
"3306",
"3308",
"3310",
"3311",
"3312",
"3313",
"3315",
"3317",
"3321",
"3322",
"3323",
"3324",
"3325",
"3332",
"3338",
"3339",
"3346",
"3354",
"3356",
"3360",
"3362",
"3363",
"3372",
"3373",
"3374",
"3376",
"3379",
"3380",
"3383",
"3388",
"3390",
"3402",
"3406",
"3413",
"3416",
"3419",
"3426",
"3428",
"3431",
"3432",
"3434",
"3437",
"3438",
"3441",
"3443",
"3444",
"3450",
"3452",
"3454",
"3455",
"3465",
"3466",
"3479",
"3481",
"3483",
"3484",
"3489",
"3490",
"3491",
"3492",
"3494",
"3498",
"3499",
"3501",
"3504",
"3508",
"3511",
"3512",
"3514",
"3515",
"3516",
"3518",
"3519",
"3520",
"3521",
"3522",
"3523",
"3526",
"3527",
"3528",
"3529",
"3531",
"3532",
"3533",
"3535",
"3536",
"3537",
"3540",
"3541",
"3545",
"3546",
"3548",
"3550",
"3551",
"3552",
"3553",
"3555",
"3556",
"3557",
"3558",
"3559",
"3561",
"3562",
"3563",
"3564",
"3567",
"3570",
"3576",
"3577",
"3579",
"3580",
"3581",
"3583",
"3587",
"3588",
"3591",
"3593",
"3594",
"3596",
"3605",
"3607",
"3609",
"3611",
"3615",
"3617",
"3622",
"3623",
"3624",
"3625",
"3628",
"3629",
"3630",
"3631",
"3632",
"3642",
"3645",
"3646",
"3652",
"3653",
"3661",
"3662",
"3663",
"3664",
"3665",
"3666",
"3669",
"3672",
"3673",
"3675",
"3679",
"3680",
"3682",
"3684",
"3685",
"3686",
"3687",
"3689",
"3691",
"3693",
"3694",
"3698",
"3701",
"3702",
"3703",
"3704",
"3705",
"3706",
"3707",
"3708",
"4102",
"4103",
"4104",
"4105",
"4106",
"4107",
"4108",
"4109",
"4111",
"4113",
"4114",
"4116",
"4119",
"4120",
"4121",
"4123",
"4126",
"4127",
"4128",
"4129",
"4130",
"4131",
"4133",
"4137",
"4138",
"4139",
"4141",
"4142",
"4144",
"4147",
"4152",
"4153",
"4154",
"4157",
"4160",
"4161",
"4162",
"4163",
"4164",
"4167",
"4168",
"4171",
"4173",
"4174",
"4175",
"4180",
"4183",
"4188",
"4190",
"4192",
"4198",
"4205",
"4207",
"4303",
"4304",
"4305",
"4306",
"4401",
"4402",
"4406",
"4413",
"4414",
"4415",
"4416",
"4417",
"4419",
"4420",
"4426",
"4429",
"4430",
"4432",
"4433",
"4438",
"4502",
"4503",
"4506",
"4510",
"4513",
"4523",
"4526",
"4527",
"4528",
"4529",
"4530",
"4532",
"4533",
"4534",
"4535",
"4536",
"4541",
"4542",
"4543",
"4545",
"4549",
"4550",
"4551",
"4552",
"4554",
"4555",
"4556",
"4557",
"4609",
"4702",
"4706",
"4707",
"4711",
"4712",
"4714",
"4716",
"4720",
"4721",
"4722",
"4725",
"4726",
"4728",
"4729",
"4735",
"4736",
"4737",
"4739",
"4743",
"4745",
"4746",
"4747",
"4754",
"4755",
"4762",
"4763",
"4803",
"4804",
"4806",
"4903",
"4904",
"4905",
"4906",
"4907",
"4908",
"4909",
"4911",
"4912",
"4915",
"4916",
"4919",
"4924",
"4927",
"4930",
"4933",
"4934",
"4935",
"4938",
"4939",
"4942",
"4943",
"4944",
"4946",
"4947",
"4950",
"4952",
"4953",
"4956",
"4958",
"4960",
"4965",
"4966",
"4968",
"4971",
"4972",
"4973",
"4974",
"4976",
"4977",
"4979",
"4984",
"4987",
"4991",
"4994",
"4995",
"4999",
"5007",
"5009",
"5011",
"5013",
"5014",
"5015",
"5016",
"5102",
"5201",
"5202",
"5203",
"5205",
"5206",
"5209",
"5210",
"5211",
"5212",
"5213",
"5215",
"5225",
"5227",
"5230",
"5234",
"5243",
"5245",
"5251",
"5255",
"5258",
"5259",
"5263",
"5264",
"5269",
"5272",
"5274",
"5276",
"5278",
"5281",
"5284",
"5285",
"5287",
"5288",
"5289",
"5291",
"5301",
"5302",
"5304",
"5305",
"5306",
"5309",
"5310",
"5312",
"5314",
"5315",
"5317",
"5321",
"5324",
"5328",
"5340",
"5344",
"5345",
"5347",
"5348",
"5349",
"5351",
"5353",
"5355",
"5356",
"5364",
"5371",
"5381",
"5383",
"5384",
"5386",
"5388",
"5392",
"5398",
"5403",
"5410",
"5425",
"5426",
"5432",
"5434",
"5438",
"5439",
"5443",
"5450",
"5452",
"5455",
"5457",
"5460",
"5464",
"5465",
"5468",
"5469",
"5471",
"5474",
"5475",
"5478",
"5480",
"5481",
"5483",
"5484",
"5487",
"5488",
"5489",
"5490",
"5491",
"5493",
"5498",
"5508",
"5511",
"5512",
"5514",
"5515",
"5516",
"5519",
"5520",
"5521",
"5522",
"5523",
"5525",
"5529",
"5530",
"5531",
"5533",
"5534",
"5536",
"5538",
"5543",
"5601",
"5603",
"5604",
"5607",
"5608",
"5609",
"5701",
"5703",
"5704",
"5706",
"5820",
"5871",
"5878",
"5880",
"5902",
"5903",
"5904",
"5905",
"5906",
"5907",
"6005",
"6015",
"6016",
"6020",
"6021",
"6022",
"6023",
"6024",
"6026",
"6101",
"6103",
"6104",
"6105",
"6107",
"6108",
"6109",
"6111",
"6112",
"6113",
"6114",
"6115",
"6116",
"6117",
"6118",
"6120",
"6121",
"6122",
"6123",
"6124",
"6125",
"6126",
"6127",
"6128",
"6129",
"6130",
"6131",
"6133",
"6134",
"6136",
"6138",
"6139",
"6140",
"6141",
"6142",
"6143",
"6144",
"6145",
"6146",
"6147",
"6148",
"6150",
"6151",
"6152",
"6153",
"6154",
"6155",
"6156",
"6158",
"6160",
"6161",
"6163",
"6164",
"6165",
"6166",
"6167",
"6168",
"6169",
"6170",
"6171",
"6172",
"6173",
"6174",
"6175",
"6176",
"6177",
"6179",
"6180",
"6182",
"6183",
"6184",
"6185",
"6186",
"6187",
"6188",
"6189",
"6190",
"6191",
"6192",
"6194",
"6195",
"6196",
"6197",
"6198",
"6199",
"6201",
"6202",
"6203",
"6204",
"6205",
"6206",
"6207",
"6208",
"6209",
"6210",
"6212",
"6213",
"6214",
"6215",
"6216",
"6217",
"6218",
"6219",
"6220",
"6221",
"6222",
"6223",
"6224",
"6225",
"6226",
"6227",
"6228",
"6229",
"6230",
"6231",
"6233",
"6234",
"6235",
"6236",
"6237",
"6238",
"6239",
"6240",
"6241",
"6242",
"6243",
"6244",
"6245",
"6246",
"6247",
"6248",
"6251",
"6257",
"6259",
"6261",
"6263",
"6264",
"6265",
"6266",
"6269",
"6270",
"6271",
"6274",
"6275",
"6276",
"6277",
"6278",
"6279",
"6281",
"6282",
"6283",
"6284",
"6285",
"6287",
"6289",
"6290",
"6291",
"6292",
"6294",
"6298",
"6404",
"6405",
"6409",
"6411",
"6412",
"6414",
"6415",
"6417",
"6419",
"6422",
"6426",
"6431",
"6432",
"6435",
"6438",
"6442",
"6443",
"6446",
"6449",
"6451",
"6452",
"6456",
"6457",
"6462",
"6464",
"6465",
"6469",
"6470",
"6472",
"6477",
"6482",
"6485",
"6486",
"6488",
"6492",
"6494",
"6496",
"6499",
"6504",
"6505",
"6506",
"6508",
"6509",
"6510",
"6512",
"6514",
"6523",
"6525",
"6531",
"6532",
"6533",
"6535",
"6538",
"6542",
"6548",
"6552",
"6554",
"6560",
"6568",
"6569",
"6577",
"6594",
"6603",
"6605",
"6609",
"6803",
"7402",
"8011",
"8016",
"8021",
"8024",
"8027",
"8032",
"8033",
"8034",
"8038",
"8039",
"8040",
"8042",
"8043",
"8044",
"8046",
"8047",
"8048",
"8049",
"8050",
"8054",
"8059",
"8064",
"8066",
"8067",
"8068",
"8069",
"8070",
"8071",
"8072",
"8074",
"8076",
"8077",
"8080",
"8081",
"8083",
"8084",
"8085",
"8086",
"8087",
"8088",
"8091",
"8092",
"8093",
"8096",
"8097",
"8099",
"8101",
"8103",
"8105",
"8107",
"8109",
"8110",
"8111",
"8112",
"8114",
"8121",
"8131",
"8147",
"8150",
"8155",
"8163",
"8171",
"8176",
"8182",
"8183",
"8201",
"8210",
"8213",
"8215",
"8222",
"8234",
"8240",
"8249",
"8255",
"8261",
"8271",
"8277",
"8279",
"8287",
"8289",
"8291",
"8299",
"8341",
"8349",
"8354",
"8358",
"8374",
"8383",
"8390",
"8401",
"8403",
"8404",
"8406",
"8409",
"8410",
"8411",
"8415",
"8416",
"8418",
"8420",
"8421",
"8422",
"8423",
"8424",
"8426",
"8427",
"8429",
"8431",
"8432",
"8433",
"8435",
"8436",
"8437",
"8442",
"8443",
"8444",
"8446",
"8450",
"8454",
"8455",
"8462",
"8463",
"8464",
"8466",
"8467",
"8472",
"8473",
"8476",
"8477",
"8480",
"8481",
"8488",
"8489",
"8905",
"8906",
"8908",
"8913",
"8916",
"8917",
"8921",
"8923",
"8924",
"8926",
"8927",
"8928",
"8929",
"8930",
"8931",
"8932",
"8933",
"8934",
"8935",
"8936",
"8937",
"8938",
"8940",
"8941",
"8942",
"8996",
"9802",
"9902",
"9904",
"9905",
"9906",
"9907",
"9908",
"9910",
"9911",
"9912",
"9914",
"9917",
"9918",
"9919",
"9921",
"9924",
"9925",
"9926",
"9927",
"9928",
"9929",
"9930",
"9931",
"9933",
"9934",
"9935",
"9937",
"9938",
"9939",
"9940",
"9941",
"9942",
"9943",
"9944",
"9945",
"9946",
"9949",
"9950",
"9951",
"9955",
"9958",
"9960",
"9962",
 };
                foreach (var item in AllStock)
                {
                    GetStock(item);
                }

            Console.ReadLine();

        }
        static void GetStock(string Stockid)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;//換成UTF8避免亂碼
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var htmlstr = wc.DownloadString(string.Format("http://goodinfo.tw/StockInfo/StockDividendSchedule.asp?STOCK_ID={0}", Stockid));
            Thread.Sleep(3000);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlstr);

            HtmlDocument hdc = new HtmlDocument();
            HtmlDocument hdd = new HtmlDocument();

            var table = doc.DocumentNode.SelectNodes("//*[@id=\"divDetail\"]");//抓table
            var list_tr = table.ToList<HtmlNode>()[0];//第1個table
            hdc.LoadHtml(list_tr.InnerHtml);//解析html
            var tr_in_tbl = hdc.DocumentNode.SelectNodes("//tr");
            var td_in_tr = tr_in_tbl.ToList<HtmlNode>();

            var fe = td_in_tr.Skip(3).Take(17).Select(tr =>
            {
                hdd.LoadHtml(tr.InnerHtml);

                var toStock =
                hdd.DocumentNode.SelectNodes("//td")
                .Select(tr2 => tr2.InnerText)
                .ToArray();

                var o = new stock();
                o.SID = int.Parse(Stockid);
                o.Sdate = toStock[2] == "" ? null : (DateTime?)DateTime.Parse(toStock[2]);
                o.ExRdate = toStock[3] == "" ? null : (DateTime?)DateTime.Parse(toStock[3]);
                o.ExR = toStock[4] == "" ? null : (Decimal?)Decimal.Parse(toStock[4]);
                o.ExDdate = toStock[5] == "" ? null : (DateTime?)DateTime.Parse(toStock[5]);
                o.ExD = toStock[6] == "" ? null : (Decimal?)Decimal.Parse(toStock[6]);
                o.Cashdate = toStock[7] == "" ? null : (DateTime?)DateTime.Parse(toStock[7]);
                o.CashDividend = toStock[8] == "" ? null : (Decimal?)Decimal.Parse(toStock[8]);
                o.StockDividendRE = toStock[11] == "" ? null : (Decimal?)Decimal.Parse(toStock[11]);
                o.StockDividendCR = toStock[14] == "" ? null : (Decimal?)Decimal.Parse(toStock[14]);

                return o;
            }).ToList(); ;

            int v = 0;
            Stock data = new Stock();
            foreach (var item in fe)
            {

                data.SID = item.SID;
                data.Sdate = item.Sdate;
                data.ExRdate = item.ExDdate;
                data.ExR = item.ExR;
                data.ExDdate = item.ExDdate;
                data.ExD = item.ExD;
                data.Cashdate = item.Cashdate;
                data.CashDividend = item.CashDividend;
                data.StockDividendRE = item.StockDividendRE;
                data.StockDividendCR = item.StockDividendCR;
                StockModel model = new StockModel();
                model.Stock.Add(data);
                model.SaveChanges();
                Console.WriteLine(Stockid + "=>" + v);

            }
            v = 0;
        }

    }

}
