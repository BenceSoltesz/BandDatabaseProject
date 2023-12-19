using BandDatabaseProject.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandDatabaseProject.Logic.Interfaces
{
    public interface ILongPlayingLogic
    {
        void Create(LongPlaying item);
        void Delete(int id);
        LongPlaying Read(int id);
        IQueryable<LongPlaying> ReadAll();
        void Update(LongPlaying item);
    }
}
