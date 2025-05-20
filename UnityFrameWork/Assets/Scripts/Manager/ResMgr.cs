using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.AddressableAssets;

public class ResMgr : UnitySingleton<ResMgr>
{
    string rootpath = "Assets/AssetPackage/";
    // 资源加载回调
    public delegate void LoadAssetCallback<T>(T asset) where T : Object;

    /// <summary>
    /// 异步加载资源（编辑器用AssetDatabase，运行时用Addressables）
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <param name="path">资源路径</param>
    /// <param name="callback">加载完成回调</param>
    public void LoadAssetAsync<T>(string path, LoadAssetCallback<T> callback) where T : Object
    {
#if UNITY_EDITOR
        //编辑器使用AssetDatabase加载
        string fullPath = rootpath + path;
        T asset = AssetDatabase.LoadAssetAtPath<T>(fullPath);
        callback?.Invoke(asset);
        return;
#else
        // 运行时使用Addressables加载
        string fullPath = rootpath + path;
        Addressables.LoadAssetAsync<T>(fullPath).Completed += handle =>
        {
            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(handle.Result);
            }
            else
            {
                Debug.LogError($"Failed to load asset at path: {fullPath}");
                callback?.Invoke(null);
            }
        };
#endif
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="asset">要释放的资源</param>
    public void ReleaseAsset(Object asset)
    {
#if UNITY_EDITOR
        // 编辑器模式下不需要释放
        if (!Application.isPlaying)
            return;
#endif
        Addressables.Release(asset);
    }

    /// <summary>
    /// 释放所有资源
    /// </summary>
    public void ReleaseAll()
    {
#if UNITY_EDITOR
        // 编辑器模式下不需要释放
        if (!Application.isPlaying)
            return;
#endif
        // Addressables.ReleaseAll();
    }
}