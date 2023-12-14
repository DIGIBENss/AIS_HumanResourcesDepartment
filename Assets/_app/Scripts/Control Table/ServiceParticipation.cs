using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceParticipation
{
    DB db;

    public ServiceParticipation()
    {
        db = new DB();
    }
    public int GetNewID()
    {
        var conn = db.GetConnection();
        var maxId = conn.Table<Participation_In_Training>().Max(o => (int?)o.ID_Participation) ?? 0;
        return maxId + 1;
    }
    public IEnumerable<Participation_In_Training> GetParticipationsID(int id)
    {
        return db.GetConnection().Table<Participation_In_Training>().Where(x => x.ID_Participation == id);
    }
    public Participation_In_Training GetParticipationID(int id)
    {
        return db.GetConnection().Table<Participation_In_Training>().Where(x => x.ID_Participation == id).FirstOrDefault();
    }
}
