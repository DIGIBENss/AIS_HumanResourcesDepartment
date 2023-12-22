using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceVacation
{
    DB db;

    public ServiceVacation()
    {
        db = new DB();
    }
    public int GetNewID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Vacation>().Max(o => (int?)o.ID_Vacation) ?? 0;
        return maxId + 1;
    }
    public IEnumerable<Vacation> GetVacationsID(int id)
    {
        return db.GetConnection().Table<Vacation>().Where(x => x.ID_Vacation == id);
    }
    public Vacation GetVacationID(int id)
    {
        return db.GetConnection().Table<Vacation>().Where(x => x.ID_Vacation == id).FirstOrDefault();
    }
}
