using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Models
{
    public class Bus
    {
        public Guid Uid { get; }
        public List<Validator> Validators { get; }
        public List<Human> People { get; }
        public List<StandReader> StandReaders { get; }
        public const int MaxPeople = 20;

        public BusStation CurrentStation { get; set; }


        /// <summary> Общее кол-во людей </summary>
        public int GeneralPeopleCount { get; }
        /// <summary> Заплатившие люди </summary>
        public int PayedPeopleCount { get; }
        /// <summary> Безбилетник люди </summary>
        public int PeopleWithoutTickets => GeneralPeopleCount - PayedPeopleCount;

        public Bus(Guid busUid, List<Validator> validators, List<StandReader> standReaders)
        {
            Validators = validators;
            StandReaders = standReaders;
            Uid = busUid;
        }
    }
}
