
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonoEmployee : MonoBehaviour
{
    [SerializeField] private MainScene _mainscene;
    [SerializeField] private TableDisplay _tabledisplay;
    [SerializeField] private MonoPosition _monoposition;
    [SerializeField] private ManagerTable _managertable;
    public ServiceEmployee ServiceEmployee;
    private Service _service;
    private void Start()
    {
        _service = new Service();
        ServiceEmployee = new ServiceEmployee();
        OnGetDataTable();
    }
    public void OnGet(string searchText)
    {
        var employees = ServiceEmployee.SearchEmployees(searchText);
       var positions = _service.GetAll<Position>();
        _mainscene.ToConsole(employees, positions);
    }
    public void OnGetEmployeesByID(int id)
    {
        var employee = ServiceEmployee.GetEmployeesID(id);
        var positions = _service.GetAll<Position>();
        _mainscene.ToConsole(employee, positions);
    }  
    public void OnGetDataTable()
    {
        _tabledisplay.ClearTable();
        var employees = _service.GetAll<Employee>();
        var positions = _service.GetAll<Position>();

        foreach (var employee in employees)
        {
            Position employeePosition = positions.FirstOrDefault(p => p.ID_Position == employee.Position_ID);
            if (employeePosition != null)
            {
                _tabledisplay.CreateDisplay(employee, employeePosition);
            }
        }
    }
    public void AddDateTable()
    {
        int nextemployeeid = ServiceEmployee.GetNewID();
        Employee newemployee = new Employee
        {
            ID_Employee = nextemployeeid,
            Position_ID = 0,
        };
        _service.Add(newemployee);
        _managertable.AddEmployeeDisplayID(newemployee, nextemployeeid);
    }

}
