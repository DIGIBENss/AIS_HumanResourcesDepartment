using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Vacation : MonoBehaviour
{
    public int ID_Vacation;
    [SerializeField] private ManagerTable _visit;
    private void Start()
    {
        _visit = FindObjectOfType<ManagerTable>();
    }
    public void GetVacationID(int id) => ID_Vacation = id;
    public void Choice(int value)
    {
        if (_visit != null && value >= 0 && value <= 9999)
        {
            Debug.Log(value);
            Debug.Log(ID_Vacation);
            _visit.NotNullVacation(ID_Vacation, value);
        }
    }
}
