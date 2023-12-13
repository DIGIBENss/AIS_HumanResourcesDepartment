using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataButtonUpdate : MonoBehaviour
{
    [SerializeField]private ManagerTable _managaertable;
    void Start()
    {
        _managaertable = GetComponentInParent<ManagerTable>();
    }
    public void OnUpdateData()
    {
        //_managaertable.UpdateEmployee();
    }
}
