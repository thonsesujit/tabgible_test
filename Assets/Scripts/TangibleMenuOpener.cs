using UnityEngine;
using UnityEngine.UI;
using System;
using TE;
using Assets.Scripts;
/// <summary>
/// This script will Open and close Menu-pannel with the rotation of Tangibles. 
/// Add directly to your game object.
/// Anticlockwise turn will open the menu, Clockwise turn will close the menue and also the menu will close automatically when the Tangible is lifted up.
/// </summary>

//TODO: to speedup the process. update method has to be reduced.
 
public class TangibleMenuOpener : MonoBehaviour {

    // This pannel will open depending upon the rotation.
    public GameObject Panel1;
    public GameObject ProcessConnection;

    [NonSerialized]
    private float _rotation;
    public int _inttialRotation;
    public int _currentRotation;
    private RectTransform _rect;

    private bool syncBool =  false;

    private PannelOpenerInterface panelOpener = new ConcretePannelOpener();


    private void Update()
    {
        TangibleEngine.OnTangibleAdded += HandleOnTangibleAdded;
        TangibleEngine.OnTangibleUpdated += HandleOnTangibleUpdated;
        TangibleEngine.OnTangibleRemoved += HandleOnTangibleRemoved;
    }

    private void HandleOnTangibleAdded(Tangible obj)
    {
        if (this != null)
        {
            if (this.name == obj.PatternId.ToString())
            {
                InitialRotation(obj);
            }
        }
                 

    }
    private void HandleOnTangibleUpdated(Tangible obj)
    {
        if (this != null)
        {
            if (this.name == obj.PatternId.ToString())
            {
                _currentRotation = (int)Math.Ceiling(obj.R);

                if (_currentRotation > _inttialRotation)
                {
                    OpenPanel();
                    _inttialRotation = _currentRotation;
                    syncBool = true;

                }

                if (_currentRotation < _inttialRotation)
                {
                    ClosePanel();

                    _inttialRotation = _currentRotation;
                }
            }
        }
               
    }

    private void HandleOnTangibleRemoved(Tangible obj)
    {
        if (this != null)
        {
            if (this.name == obj.PatternId.ToString())
            { panelOpener.ClosePanel(Panel1); }
        }
               
    }

    public void InitialRotation(Tangible Obj)
    {
        _inttialRotation = (int)Math.Ceiling(Obj.R);

   }


    public void OpenPanel()
    {
        panelOpener.OpenPannel(Panel1);

       
        if (syncBool == true)
        {
            panelOpener.OpenPannel(ProcessConnection);
            syncBool = false;

        }
               
    }


    public void ClosePanel()
    {
        panelOpener.ClosePanel(Panel1);
        panelOpener.ClosePanel(ProcessConnection);
        syncBool = false;

    }

}
