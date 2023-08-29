using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    public class UpdateRoomQuery
    {
        public string NewName { get; }
        public int NewArea { get; }
        public int NewVoltage { get; }

        public bool NewGasConnected { get; }
        //public UpdateRoomQuery(string nName = null, int nArea = 0)
        public UpdateRoomQuery(string nName = null, int nArea = 0, bool nGasConnected = false, int nVoltage = 0)
        {
            NewName = nName;
            NewArea = nArea;
            NewGasConnected = nGasConnected;
            NewVoltage = nVoltage;
        }
        
      
    }
}
