using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    abstract class PannelOpenerInterface
    {
        public abstract void OpenPannel (GameObject gameObject);
        public abstract void ClosePanel(GameObject gameObject);
    }
}
