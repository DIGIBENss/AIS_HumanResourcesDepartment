using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Position : MonoBehaviour
{
    public int ID_Employee;
    [SerializeField] private ManagerTable _visit;
    private void Start()
    {
        _visit = FindObjectOfType<ManagerTable>();
    }
    public void GetEmployeeID(int id) => ID_Employee = id;
    public void Choice(int value)
    {
      if (_visit != null && value >= 0 && value <= 9999)
      {
        value++;
        Debug.Log(value);
        Debug.Log(ID_Employee);
        _visit.NotNullCategory(ID_Employee, value);
      }
    }
}
