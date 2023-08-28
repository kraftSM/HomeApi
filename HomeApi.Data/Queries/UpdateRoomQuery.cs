using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Data.Queries
{
    internal class UpdateRoomQuery
    {
        public string NewName { get; }
        public int NewArea { get; }
        //public int NewVoltage { get; }

        //public bool NewGasConnected { get; }
        //public UpdateRoomQuery(int nArea = 0, bool nGasConnected = false, int nVoltage = 0)
        // обновляем пока имя и территорию- только
        public UpdateRoomQuery(string nName = null, int nArea = 0)

        {
            NewName = nName;
            NewArea = nArea;
            //NewGasConnected = nGasConnected;
            //NewVoltage = nVoltage;
        }
        
      
    }
}
