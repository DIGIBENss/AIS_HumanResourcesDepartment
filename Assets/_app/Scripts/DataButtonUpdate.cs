using UnityEngine;

public class DataButtonUpdate : MonoBehaviour
{
    [SerializeField]private ManagerTable _managaertable;
    void Start()
    {
        _managaertable = GetComponentInParent<ManagerTable>();
    }
    public void OnUpdateDataEmployee()
    {
        _managaertable.UpdateEmployee();
    }
    public void OnUpdateDataPosition()
    {
        _managaertable.UpdatePosition();
    }
    public void OnUpdateDataParticipation()
    {
        _managaertable.UpdateParticipation();
    }
}
