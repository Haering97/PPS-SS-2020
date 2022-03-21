using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker1 : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Image manager on the AR Session Origin")]
    ARTrackedImageManager m_TrackedImageManager;
    [SerializeField]
    [Tooltip("Reference Image Library")]
    XRReferenceImageLibrary m_ImageLibrary;


    void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            Debug.Log("PP-Log: Test");
            Debug.Log(newImage.referenceImage.name);

            if(newImage.referenceImage.guid == m_ImageLibrary[0].guid)
            {
                Debug.Log("PP-Log: --------------sameID--------------");
                
            }

            /*
            for(int i = 0; i < m_ImageLibrary.count ; i++)
            {
                Debug.Log("PP-Log:" +m_ImageLibrary[i].name);
            }
            */

            Debug.Log(m_ImageLibrary);

            
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            //Debug.Log(updatedImage.trackableId);
            // Handle updated event
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
        }
    }
}
