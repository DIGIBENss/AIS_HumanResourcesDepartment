
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MainScene : MonoBehaviour
{
    private Service _service;
    [SerializeField] private TableDisplay _employeeDisplay;
    [SerializeField] private TextMeshProUGUI _textcoutsearch;
    [SerializeField] private ManagerTable _managerTable;
    public int SearchCout;
    public bool Search = true;
    private void Start()
    {
        _service = new Service();
    }
    public void OnCreateDB()
    {
        Debug.Log("-----OnCreateDB-----");
        _service.CreateTable();
    }
    public void ToConsole(IEnumerable<Employee> employees, IEnumerable<Position> positions)
    {
        _employeeDisplay.ClearTable();
        SearchCout = 0;

            foreach (var employee in employees)
            {
                Position employeePosition = positions.FirstOrDefault(p => p.ID_Position == employee.ID_Position);
                if (employeePosition != null)
                {
                    _employeeDisplay.CreateDisplay(employee, employeePosition);
                }
            }
    }
    public void ToOne(Employee employee)
    {
        _employeeDisplay.ClearTable();
        _managerTable.CreateEmployeeDisplayID(employee);
    }
    private void ToConsole(string msg)
    {
        SearchCout++;
        _textcoutsearch.text = SearchCout.ToString();
        Debug.Log(msg);
    }
}
