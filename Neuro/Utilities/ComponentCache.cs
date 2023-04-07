﻿using Neuro.Utilities.Collections;
using UnityEngine;

namespace Neuro.Utilities;

/// <summary>
/// Caches all components of type T in the scene (including disabled ones)
/// </summary>
/// <typeparam name="T"></typeparam>
public static class ComponentCache<T> where T : Component
{
    public static SelfUnstableList<T> Cached { get; } = new();

    public static SelfUnstableList<T> FetchObjects()
    {
        Cached.Clear();
        Cached.AddRange(GameObject.FindObjectsOfType<T>(true));
        return Cached;
    }
}
