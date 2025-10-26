using Enums;
using UnityEngine;

namespace Interfaces
{
    public interface IViewFactory
    {
        GameObject GetViewPrefab(ViewType viewType);
    }
}