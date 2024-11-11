using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json; // For JSON serialization
using TMPro;
using System.Linq;


public class MainMenu : MonoBehaviour
{
    public static Dictionary<string, double[]> us_data = new()
    {
        { "1980", new double[] { 37.792366, 75.3600823, 138.7051734, 84.38333333, 148.824221,   156.2132569 } },
        { "1981", new double[] { 41.6981, 79.80599647, 124.5590829, 89.86666667, 158.4950029, 0, 161.3205467 } },
        { "1982", new double[] { 44.254787, 78.00558495, 140.8546443, 86.68333333, 152.8806584, 0, 157.3155497 } },
        { "1983", new double[] { 45.676445, 85.06025867, 130.0521752, 89.36666667, 157.6131687, 0, 159.7589653 } },
        { "1984", new double[] { 47.640778, 79.23647854, 144.7861552, 100.4666667, 177.1898883, 676.9547325, 178.5898001 } },
        { "1985", new double[] { 49.32995, 80.8899177, 150.8487654, 80.35833333, 141.7254556, 672.0127866, 168.2649912 } },
        { "1986", new double[] { 50.266254, 84.83980012, 170.5063198, 86.95833333, 153.3656673, 673.1518225, 184.0828924 } },
        { "1987", new double[] { 52.10829, 80.42328042, 160.3835979, 78.25833333, 138.0217519, 680.739271, 173.0232216 } },
        { "1988", new double[] { 54.233135, 92.18841858, 160.8428865, 78.95, 139.2416226, 721.0464433, 188.1981188 } },
        { "1989", new double[] { 56.85097, 98.91240447, 151.7122281, 99.78333333, 175.9847149, 757.2751323, 204.3650794 } },
        { "1990", new double[] { 59.91976, 102.127425, 158.3994709, 101.3916667, 178.8212816, 0, 198.228983 } },
        { "1991", new double[] { 62.45734, 106.0405644, 195.1425632, 98.925, 174.4708995, 0, 194.0770135 } },
        { "1992", new double[] { 64.34906, 100.9883892, 196.244856, 86.01666667, 151.7048795, 0, 191.6519694 } },
        { "1993", new double[] { 66.24842, 96.72619048, 183.7889477, 91.14166667, 160.7436802, 0, 196.244856 } },
        { "1994", new double[] { 67.975815, 101.8885949, 177.0833333, 86.28333333, 152.1751911, 0, 198.6147854 } },
        { "1995", new double[] { 69.88282, 107.9512052, 183.9910347, 92.45, 163.0511464, 0, 202.0870076 } },
        { "1996", new double[] { 71.93123, 107.9328336, 205.026455, 110.6333333, 195.1205173, 669.20194, 214.4326867 } },
        { "1997", new double[] { 73.612755, 107.271458, 199.9191652, 105.8333333, 186.6549089, 625.8818342, 220.8810994 } },
        { "1998", new double[] { 74.75543, 108.888154, 207.9107878, 103.7416667, 182.9659024, 731.9223986, 230.085244 } },
        { "1999", new double[] { 76.391106, 108.2084068, 197.7329512, 95.925, 169.1798942, 766.1485891, 232.7858613 } },
        { "2000", new double[] { 78.97072, 110.4497354, 202.5646678, 91.35, 161.1111111, 723.6735744, 236.1478542 } },
        { "2001", new double[] { 81.20257, 111.6990006, 191.4498824, 92.93333333, 163.9035861, 791.5380658, 243.643445 } },
        { "2002", new double[] { 82.49046, 111.882716, 208.9763374, 103.2, 182.010582, 873.8425926, 236.7541152 } },
        { "2003", new double[] { 84.363075, 112.1399177, 215.9942681, 124.4416667, 219.4738389, 800.5401235, 228.0460024 } },
        { "2004", new double[] { 86.62168, 109.1820988, 229.9199001, 133.95, 236.2433862, 882.8079071, 235.7987948 } },
        { "2005", new double[] { 89.56053, 108.5023516, 209.3070253, 121.8166667, 214.8442093, 977.8071723, 232.7491182 } },
        { "2006", new double[] { 92.44971, 110.3027631, 235.1190476, 130.625, 230.3791887, 989.5649618, 231.3345091 } },
        { "2007", new double[] { 95.08699, 112.4706055, 245.8664021, 167.625, 295.6349206, 839.3224574, 245.8480306} },
        { "2008", new double[] { 98.73748, 134.3327454, 290.9685479, 198.65, 350.3527337, 907.1134627, 266.0751029 } },
        { "2009", new double[] { 98.38642, 134.7369195, 260.4901529, 166.4, 293.4744268, 767.4162257, 281.7827748 } },
        { "2010", new double[] { 100, 127.792475, 269.0145503, 165.9666667, 292.7101705, 814.3922693, 278.4758965 } },
        { "2011", new double[] { 103.156845, 134.5164609, 297.6925338, 176.95, 312.0811287, 1148.974868, 284.6854791} },
        { "2012", new double[] { 105.291504, 132.7344209, 303.5898001, 183.7666667, 324.1034685, 1108.686067, 313.5288066 } },
        { "2013", new double[] { 106.83385, 132.1832745, 305.5355139, 190.95, 336.7724868, 1091.269841, 329.8427396 } },
        { "2014", new double[] { 108.56693, 131.8525867, 298.4273956, 201.85, 355.9964727, 1170.74515, 338.0180776 } },
        { "2015", new double[] { 108.695724, 128.4722222, 299.382716, 246.9416667, 435.5232216, 1122.850529, 328.0974427 } },
        { "2016", new double[] { 110.06701, 126.3227513, 317.9613596, 168.4166667, 297.0311581, 1116.843034, 322.6778366 } },
        { "2017", new double[] { 112.41156, 124.0263081, 285.361552, 146.7083333, 258.744856, 1024.011611, 324.4966196 } },
        { "2018", new double[] { 115.1573, 126.5064668, 0, 174.1666667, 307.1722516, 1045.579806, 330.0448266 } },
        { "2019", new double[] { 117.244194, 126.4513521, 0, 139.5833333, 246.1787184, 1159.556878, 329.5855379 } },
        { "2020", new double[] { 118.6905, 127.4066725, 0, 150.575, 265.5643739, 1149.489271, 344.5566779 } },
        { "2021", new double[] { 124.26641, 132.2935038, 0, 167.4, 295.2380952, 1204.071135, 336.5483539 } },
        { "2022", new double[] { 134.21121, 140.3218695, 0, 285.6833333, 503.8506761, 1351.668136, 396.9723692 } },
        { "2023", new double[] { 134.21121, 138.9807466, 0, 279.6166667, 493.1510876, 1291.317607, 421.994415 } },
    };


    public static Dictionary<string, double[]> uk_data = new()
    {
        { "1980", new double[] { 33.67315, 60, 54, 0, 36.5, 209.2, 148 } },
        { "1981", new double[] { 37.672386, 63, 55, 0, 39.8, 231.5, 154 } },
        { "1982", new double[] { 40.91178, 70, 68, 0, 42.2, 250.8, 159 } },
        { "1983", new double[] { 42.79753, 80, 66, 0, 43.8, 254.5, 164 } },
        { "1984", new double[] { 44.920593, 87, 70, 0, 45.9, 258, 172 } },
        { "1985", new double[] { 47.6479, 97, 71, 0, 48.1, 273.6, 176 } },
        { "1986", new double[] { 49.281082, 101, 76, 0, 53.8, 275.1, 177 } },
        { "1987", new double[] { 51.325714, 106, 80, 0, 55.4, 275.3, 181 } },
        { "1988", new double[] { 53.45848, 106, 76, 0, 58.7, 300.2, 183 } },
        { "1989", new double[] { 56.537823, 106, 82, 0, 61.6, 323.3, 194 } },
        { "1990", new double[] { 61.096725, 114, 103, 0, 65.2, 329.5, 217 } },
        { "1991", new double[] { 65.65563, 119, 120, 0, 69.5, 344.6, 230 } },
        { "1992", new double[] { 68.67024, 106, 121, 0, 72.8, 382.7, 200 } },
        { "1993", new double[] { 70.42722, 100, 86, 0, 75.2, 411.2, 210 } },
        { "1994", new double[] { 71.99001, 100, 98, 0, 74, 422.6, 202 } },
        { "1995", new double[] { 73.93194, 92, 100, 0, 74.8, 456.9, 203 } },
        { "1996", new double[] { 76.04032, 93, 112, 0, 71.6, 484.4, 229 } },
        { "1997", new double[] { 77.71407, 102, 112, 0, 70.6, 528, 240 } },
        { "1998", new double[] { 79.12891, 107, 105, 0, 70.8, 500.1, 226 } },
        { "1999", new double[] { 80.516, 104, 103, 0, 68.8, 484.2, 220 } },
        { "2000", new double[] { 81.46847, 99, 108, 0, 70.2, 504.6, 223 } },
        { "2001", new double[] { 82.71685, 106, 116, 0, 71.2, 509.8, 227 } },
        { "2002", new double[] { 83.97448, 103, 121, 0, 74, 523.8, 224 } },
        { "2003", new double[] { 85.13039, 92, 127, 0, 83.9, 548.1, 228 } },
        { "2004", new double[] { 86.31404, 86, 125, 0, 90.9, 567.4, 232 } },
        { "2005", new double[] { 88.117256, 92, 118, 0, 84.7, 549.7, 230 } },
        { "2006", new double[] { 90.28112, 90, 122, 0, 89.7, 565.7, 224 } },
        { "2007", new double[] { 92.43573, 87, 132, 0, 92.2, 577.8, 227 } },
        { "2008", new double[] { 95.69077, 90, 147, 0, 109.2, 695.5, 280 } },
        { "2009", new double[] { 97.56797, 93, 153, 0, 109.9, 749.8, 290 } },
        { "2010", new double[] { 100, 98, 165, 319, 110.3, 779.3, 288 } },
        { "2011", new double[] { 103.85611, 85, 174, 319, 120, 780.1, 313 } },
        { "2012", new double[] { 106.52857, 87, 175, 316, 126.7, 788.8, 313 } },
        { "2013", new double[] { 108.96986, 88, 202, 307, 137.8, 777.8, 330 } },
        { "2014", new double[] { 110.55114, 87, 197, 309, 135.2, 801.6, 333 } },
        { "2015", new double[] { 110.958015, 86, 196, 278, 118.7, 766.6, 313 } },
        { "2016", new double[] { 112.076935, 85, 196, 259, 112.4, 718.8, 292 } },
        { "2017", new double[] { 114.94359, 90, 197, 245, 115.6, 718.2, 282 } },
        { "2018", new double[] { 117.57906, 93, 210, 236, 114.6, 727.7, 282 } },
        { "2019", new double[] { 119.62271, 95, 199, 228, 117.9, 708.7, 275 } },
        { "2020", new double[] { 120.80636, 87, 194, 225, 117.1, 688.5, 254 } },
        { "2021", new double[] { 123.84872, 80, 226, 213, 117.6, 628.3, 271 } },
        { "2022", new double[] { 133.66006, 90, 219, 0, 133.1, 709.1, 320 } },
        { "2023", new double[] { 133.66006, 109, 213, 0, 156.8, 918.5, 380 } }
    };



    public TMP_InputField amountInput;
    public TMP_Text yearText;

    private const float USDToGBPConversion = 0.77f;

    public static double GetHistoricalValue(Dictionary<string, double[]> data, double currentValue, string year)
    {
        string baseYear = "2023"; 

        year = year.Trim();
        baseYear = baseYear.Trim();

        Debug.Log($"Year: {year}, Base Year: {baseYear}");

        if (data.TryGetValue(year, out double[] targetYearData) && data.TryGetValue(baseYear, out double[] baseYearData))
        {
            double targetCPI = targetYearData[0];
            double baseCPI = baseYearData[0];

            Debug.Log($"targetCPI = {targetCPI}, baseCPI = {baseCPI}");


            // Calculate historical value
            return currentValue * (targetCPI / baseCPI);
        }
        else
        {
            Debug.Log("CPI data not available for the given year.");
            return -1; // Return a fallback value or throw an exception as needed
        }
    }

    public Dictionary<string, double> GetUSProductCombinations(){
        if (double.TryParse(amountInput.text, out double amount) && !string.IsNullOrEmpty(yearText.text))
        {
            string year = yearText.text;
            Debug.Log("Amount Input: " + amount);
            Debug.Log("Year Input: " + year);

            double historicalValue = GetHistoricalValue(us_data, (amount * USDToGBPConversion), year);
            Debug.Log($"The equivalent value of £{amount} in {year} is approximately £{historicalValue}");


            return getProductCombination(amount, year, "US");            
        }
        else
        {
            Debug.Log("Invalid amount or year input.");
            return new Dictionary<string, double>(); // Return an empty dictionary

        }
    }

    public Dictionary<string, double>  GetUKProductCombinations()
    {
        if (double.TryParse(amountInput.text, out double amount) && !string.IsNullOrEmpty(yearText.text))
        {
            string year = yearText.text;
            Debug.Log("Amount Input: " + amount);
            Debug.Log("Year Input: " + year);

            double historicalValue = GetHistoricalValue(uk_data, amount, year);
            Debug.Log($"The equivalent value of £{amount} in {year} is approximately £{historicalValue}");

            
            return getProductCombination(amount, year, "UK");
        }
        else
        {
            Debug.Log("Invalid amount or year input.");
            return new Dictionary<string, double>(); // Return an empty dictionary
        }
    }

    private double[] getProductPrices(string country, string year){
        year = year.Trim();

        double[] result = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };

        Dictionary<string, double[]> data = country == "US" ? us_data : uk_data;

        // Check if the target year exists in the dictionary
        if (data.TryGetValue(year, out double[] targetYearData)){
            result = targetYearData;
            Debug.Log("Reult found! " + result);
        }

        // Return the result array (will be [0.0, 0.0] if year not found)
        return result;
        }

    // country is either "US" or "UK"
    public Dictionary<string, double> getProductCombination(double old_money, string year, string country) 
    {
        old_money = old_money * 100;
        // Get the prices for the given country and year
        var product_prices = getProductPrices(country, year);
        Debug.Log("Product prices are: " + string.Join(", ", product_prices));


        // Initialize the dictionary to hold product names and prices
        var labelled_product_prices = new Dictionary<string, int>();
        var product_names = new string[] { "CPI", "banana", "apple", "eggs", "bread", "cheese", "chicken" };

        // Populate the dictionary with product names and their corresponding prices
        for (int i = 1; i < product_prices.Length; i++) // Start at index 1 to skip "CPI"
        {
            if (product_prices[i] != 0)
            {
                labelled_product_prices.Add(product_names[i], (int)product_prices[i]);
            }
        }

        // Sort the prices in descending order by value
        var sorted_labelled_product_prices = labelled_product_prices
            .OrderByDescending(x => x.Value)
            .ToList();

        // Initialize the remaining money and the summary dictionary
        int remaining_money = (int)old_money;
        var combination_summary = new Dictionary<string, double>
        {
            { "banana", 0 },
            { "apple", 0 },
            { "eggs", 0 },
            { "bread", 0 },
            { "cheese", 0 },
            { "chicken", 0 }
        };

        // Get the smallest price
        int smallest_price = sorted_labelled_product_prices.Last().Value;

        // Try to buy products while there is enough money
        while (remaining_money - smallest_price >= 0)
        {
            // Try to buy the most expensive products first
            foreach (var (product_name, price) in sorted_labelled_product_prices)
            {
                if (remaining_money - price >= 0)
                {
                    remaining_money -= price; // Subtract the price of the product
                    combination_summary[product_name] += 1; // Increment the product count
                }
            }
        }

        return combination_summary; // Return the summary
    }

    public void Visualise(){
        var usProductCombinations = GetUSProductCombinations();
        var ukProductCombinations = GetUKProductCombinations();

        // Convert each dictionary to a JSON string
        string usJson = JsonConvert.SerializeObject(usProductCombinations);
        string ukJson = JsonConvert.SerializeObject(ukProductCombinations);

        // Store the JSON strings in PlayerPrefs
        PlayerPrefs.SetString("USProductCombinations", usJson);
        PlayerPrefs.SetString("UKProductCombinations", ukJson);
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}