using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaverecnaPraceBaseDLL
{
    public interface IGameForm
    {
        void StartGame();
        
        void EndGame();

        void Restart();

        Form InitForm(IMainForm mainForm);

    }
}
