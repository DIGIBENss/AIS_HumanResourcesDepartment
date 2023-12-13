
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Linq;

public class SearchManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField _searchInputField;
    [SerializeField] private MonoEmployee _employee;
    [SerializeField] private List<Employee> _employees = new List<Employee>();
    public void OnSearch()
    {
        string searchText = _searchInputField.text;
        Debug.Log(searchText);

        _employee.OnGet(searchText);
    }
}
