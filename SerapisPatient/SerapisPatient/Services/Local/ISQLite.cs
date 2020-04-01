using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Services.Local
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
