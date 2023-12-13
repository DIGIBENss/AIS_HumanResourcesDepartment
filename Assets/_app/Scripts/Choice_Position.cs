using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Position : MonoBehaviour
{
    public int ID_Employee;
    private ManagerTable _visit;
    private void Awake()
    {
    }
    private void Start()
    {
        _visit = GetComponentInParent<ManagerTable>();
    }
    public void GetPositionID(int id) => ID_Employee = id;
    public void Choice(int value)
    {
        if (_visit != null)
        {
            value++;
            switch (value)
            {
                case 0:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 1:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 2:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 3:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 4:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 5:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 6:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 7:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 8:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 9:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                case 10:
                    _visit.NotNullCategory(ID_Employee, value);
                    break;
                default:
                    break;
            }
        }

    }
}
