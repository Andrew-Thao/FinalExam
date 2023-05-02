using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        dropdown.ClearOptions(); // Clear the dropdown options

        // Add values ranging from 1 to 9 to the dropdown
        for (int i = 1; i <= 9; i++)
        {
            dropdown.options.Add(new Dropdown.OptionData(i.ToString()));
        }

        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(); }); // Set listener for when the dropdown value changes
    }

    void DropdownValueChanged()
    {
        // Get the selected value from the dropdown
        int selectedValue = dropdown.value + 1;

        // Save the selected value to a PlayerPrefs variable
        PlayerPrefs.SetInt("lives", selectedValue);
    }
}