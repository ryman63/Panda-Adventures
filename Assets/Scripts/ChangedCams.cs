using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class ChangedCams : MonoBehaviour
{
    public enum Scene { Start, Settings, GameLevel1 }

    private Dictionary<Scene, CinemachineVirtualCamera> cameras = new Dictionary<Scene, CinemachineVirtualCamera>();

    [SerializeField] private Scene currentCamera;

    [SerializeField] private GameObject GroupCamsUI;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonPrevious;
    [SerializeField] private Button buttonNext1;
    [SerializeField] private Button buttonPrevious1;
    [SerializeField] private Button buttonNext2;
    [SerializeField] private Button buttonPrevious2;
    void Start()
    {
        buttonNext.onClick.AddListener(ChangedCamNext);
        buttonPrevious.onClick.AddListener(ChangedCamPrevious);
        buttonNext1.onClick.AddListener(ChangedCamNext);
        buttonPrevious1.onClick.AddListener(ChangedCamPrevious);
        buttonNext2.onClick.AddListener(ChangedCamNext);
        buttonPrevious2.onClick.AddListener(ChangedCamPrevious);

        for (int i = 0; i < GroupCamsUI.transform.childCount; i++)
        {
            cameras.Add((Scene)i, GroupCamsUI.transform.GetChild(i).GetComponent<CinemachineVirtualCamera>());
        }

        currentCamera = Scene.Start;
        cameras[currentCamera].transform.gameObject.SetActive(true);
    }


    private void ChangedCamNext()
    {
        cameras[currentCamera].transform.gameObject.SetActive(false);
        if (((int)currentCamera + 1) >= GroupCamsUI.transform.childCount)
            currentCamera = 0;
        else
            currentCamera = currentCamera + 1;
        cameras[currentCamera].transform.gameObject.SetActive(true);
    }
    private void ChangedCamPrevious()
    {
        cameras[currentCamera].transform.gameObject.SetActive(false);
        if (((int)currentCamera - 1) < 0)
            currentCamera = (Scene)cameras.Count;
        else
            currentCamera = currentCamera - 1;

        cameras[currentCamera].transform.gameObject.SetActive(true);
    }
}
