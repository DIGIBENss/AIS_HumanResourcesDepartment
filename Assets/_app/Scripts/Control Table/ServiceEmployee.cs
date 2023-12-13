
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ServiceEmployee
{
    DB db;

    public ServiceEmployee()
    {
        db = new DB();
    }
    public IEnumerable<Employee> SearchEmployees(string searchText)
    {
        return db.GetConnection().Table<Employee>()
            .Where(e =>
                e.Name.Contains(searchText) ||
                e.Surname.Contains(searchText) ||
                e.Patronymic.Contains(searchText)
            );
    }
    public int GetNewID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Employee>().Max(o => (int?)o.ID_Employee) ?? 0;
        return maxId + 1;
    }
    public IEnumerable<Employee> GetEmployeesID(int id)
    {
        return db.GetConnection().Table<Employee>().Where(x => x.ID_Employee == id);
    }
    public Employee GetEmployeeID(int id)
    {
        return db.GetConnection().Table<Employee>().Where(x => x.ID_Employee == id).FirstOrDefault();
    }
}
