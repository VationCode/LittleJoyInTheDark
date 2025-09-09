using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    Key,
    Door,
    Coffin,
    Lever,
    Ending
}

[System.Serializable]
public class InteractionData
{
    public InteractionType InteractionType;
    public int ID;      //키와 문은 같은 ID로
    public string Name;
}

public abstract class InteractionComponent : MonoBehaviour
{
    public InteractionData InteractionData;
    public event Action<InteractionComponent> OnInteracted;
    public abstract bool Interact(PlayerInventory inventory);
    protected void NotifyInteracted()
    {
        OnInteracted?.Invoke(this);
    }
}
