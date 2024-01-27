using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.PageForFunctionalRequirements.ClassHelp
{
    public class RepairRequest
    {
        public int Id { get; set; }
        // Другие свойства

        private int _statusId;
        public int StatusId
        {
            get { return _statusId; }
            set
            {
                if (_statusId != value)
                {
                    _statusId = value;
                    // Вызов метода, который обновляет другие свойства, зависящие от StatusId
                }
            }
        }
    }
}
