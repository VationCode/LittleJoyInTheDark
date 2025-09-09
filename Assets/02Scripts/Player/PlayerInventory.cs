using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private readonly HashSet<int> m_keyIDs = new();

    public bool HasKey(int keyID) => m_keyIDs.Contains(keyID);
    public void AddKey(int keyID) => m_keyIDs.Add(keyID);
    public void RemoveKey(int keyID) => m_keyIDs.Remove(keyID);
}
