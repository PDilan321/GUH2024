using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using TMPro;
using System.Text;


public class SpawnerScript : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject applePrefab;
    public GameObject eggsPrefab;
    public GameObject breadPrefab;
    public GameObject cheesePrefab;
    public GameObject chickenPrefab;

    public bool IsUK = false;

    public TextMeshProUGUI ComparisonText;

    public void Start()
    {

        // Check if the PlayerPrefs have the dictionaries
        if (PlayerPrefs.HasKey("USProductCombinations") && PlayerPrefs.HasKey("UKProductCombinations"))
        {
            string json;
            if (IsUK){
                json = PlayerPrefs.GetString("UKProductCombinations");
            }
            else{
                json = PlayerPrefs.GetString("USProductCombinations");
            }

            // Deserialize into dictionaries
            Dictionary<string, double> productCombinations = JsonConvert.DeserializeObject<Dictionary<string, double>>(json);
            productCombinations = IncreaseQuantity(productCombinations);

            InstantiateProducts(productCombinations);
        }
        else
        {
            Debug.LogError("No product combinations found in PlayerPrefs.");
        }

        GetComparisonString();
    }

public Dictionary<string, double> IncreaseQuantity(Dictionary<string, double> dict)
{
    // Create a new dictionary to store the updated quantities
    Dictionary<string, double> updatedDict = new Dictionary<string, double>();

    // Iterate through each entry in the input dictionary
    foreach (var entry in dict)
    {
        string foodItem = entry.Key;
        double quantity = entry.Value;

        // Apply specific multiplication factors for certain food items
        if (foodItem == "banana")
        {
            updatedDict[foodItem] = quantity * 6;
        }
        else if (foodItem == "apple")
        {
            updatedDict[foodItem] = quantity * 5;
        }
        else if (foodItem == "eggs")
        {
            updatedDict[foodItem] = quantity * 12;
        }
        else
        {
            // If no multiplication is specified, keep the original quantity
            updatedDict[foodItem] = quantity;
        }
    }

    return updatedDict;
}


private void InstantiateProducts(Dictionary<string, double> productCombinations)
    {
        float spawnRadius = 4.5f;  // How far from center objects can spawn

        foreach (var product in productCombinations)
        {
            string productName = product.Key;
            double quantity = product.Value;

            // Instantiate the prefabs based on the product name and quantity
            for (int i = 0; i < Mathf.FloorToInt((float)quantity); i++) // Use Mathf.FloorToInt to round down to the nearest integer
            {
                GameObject prefabToInstantiate = null;

                switch (productName)
                {
                    case "banana":
                        prefabToInstantiate = bananaPrefab;
                        break;
                    case "apple":
                        prefabToInstantiate = applePrefab;
                        break;
                    case "eggs":
                        prefabToInstantiate = eggsPrefab;
                        break;
                    case "bread":
                        prefabToInstantiate = breadPrefab;
                        break;
                    case "cheese":
                        prefabToInstantiate = cheesePrefab; 
                        break;
                    case "chicken":
                        prefabToInstantiate = chickenPrefab;
                        break;
                    default:
                        Debug.LogWarning("Unknown product: " + productName);
                        continue; // Skip if the product is not recognized
                }

                if (prefabToInstantiate != null)
                {
                    float heightOffset = Random.Range(-3f, 3f);
                    Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
                    Vector3 spawnPosition = new Vector3(
                        transform.position.x + randomCircle.x,
                        transform.position.y + heightOffset,
                        transform.position.z + randomCircle.y
                    );
                    // Instantiate the prefab at a default position or you can adjust this as needed
                    Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame


    public void GetComparisonString()
    {
        if (PlayerPrefs.HasKey("USProductCombinations") && PlayerPrefs.HasKey("UKProductCombinations"))
        {
            var usJson = PlayerPrefs.GetString("USProductCombinations");
            var ukJson = PlayerPrefs.GetString("UKProductCombinations");

            Dictionary<string, double> usCombinations = JsonConvert.DeserializeObject<Dictionary<string, double>>(usJson);
            Dictionary<string, double> ukCombinations = JsonConvert.DeserializeObject<Dictionary<string, double>>(ukJson);
            usCombinations = IncreaseQuantity(usCombinations);
            ukCombinations = IncreaseQuantity(ukCombinations);

            // Initialize an empty StringBuilder for efficiency with large strings
            StringBuilder result = new StringBuilder();

            // Ensure both dictionaries have the same keys before looping
            foreach (var ukPair in ukCombinations)
            {
                string key = ukPair.Key;
                double ukValue = ukPair.Value;

                // Check if the key exists in the US dictionary
                if (usCombinations.TryGetValue(key, out double usValue))
                {
                    // Append formatted string for each entry
                    result.AppendLine($"{ukValue}, {key}, {usValue}");
                }
                else
                {
                    // Handle the case if a key is missing in the US dictionary (optional)
                    result.AppendLine($"{ukValue}, {key}, Value of US: (not available)");
                }
            }
            ComparisonText.text = result.ToString();
        }
        else{   
            ComparisonText.text = "Nothing to show here fella";

        }

    }
    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.Space)){
        //     Instantiate(cubePrefab, transform.position, Quaternion.identity);
        // }
        
    }
}
