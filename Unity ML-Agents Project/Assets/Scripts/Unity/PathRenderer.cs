using System.Collections.Generic;
using UnityEngine;

namespace DevSlem.Unity
{
    public class PathRenderer : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField, Min(0), OnValueChanged(nameof(OnMaxMaxPositionCountChanged))] 
        private int maxPositionCount;

        private List<Vector3> positions = new List<Vector3>();

        public LineRenderer LineRenderer
        {
            get => lineRenderer;
            set => lineRenderer = value;
        }

        public int MaxPositionCount
        {
            get => maxPositionCount;
            set
            {
                maxPositionCount = Mathf.Max(value, 0);
                OnMaxMaxPositionCountChanged();
            }
        }

        public void Add(Vector3 position)
        {
            AddPosition(position);
            UpdateLineRenderer();
        }

        public void AddRange(IEnumerable<Vector3> positions)
        {
            foreach (var item in positions)
            {
                AddPosition(item);
            }
            UpdateLineRenderer();
        }

        public void RemoveAt(int index)
        {
            positions.RemoveAt(index);
            UpdateLineRenderer();
        }

        public void RemoveRange(int index, int count)
        {
            positions.RemoveRange(index, count);
            UpdateLineRenderer();
        }

        public void Clear()
        {
            positions.Clear();
            UpdateLineRenderer();
        }

        private void AddPosition(Vector3 position)
        {
            // if there's no need to render
            if (positions.Count > 0 && position == positions[positions.Count - 1])
            {
                return;
            }

            if (positions.Count > maxPositionCount)
            {
                positions.RemoveAt(0);
            }

            positions.Add(position);
        }

        private void UpdateLineRenderer()
        {
            if (lineRenderer == null)
            {
                Debug.LogWarning($"Line Renderer is null.", this);
                return;
            }

            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
        }

        private void OnMaxMaxPositionCountChanged()
        {
            try
            {
                RemoveRange(maxPositionCount, positions.Count - maxPositionCount);
            }
            catch (System.ArgumentException) { }
        }
    }
}
