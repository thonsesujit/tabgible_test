using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE;
using UnityEngine;

namespace Assets.Scripts
{
    class ConcretePannelOpener : PannelOpenerInterface
    {
        public override void ClosePanel(GameObject gameObject)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }

        public override void OpenPannel(GameObject gameObject)
        {
            if (gameObject != null) // if the pannel is assigned , if not null

            {
                gameObject.SetActive(true);
            }
        }
    }
}
