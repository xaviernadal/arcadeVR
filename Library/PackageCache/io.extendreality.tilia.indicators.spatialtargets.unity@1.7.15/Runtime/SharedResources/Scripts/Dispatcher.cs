﻿namespace Tilia.Indicators.SpatialTargets
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using UnityEngine;
    using Zinnia.Data.Type;
    using Zinnia.Extension;
    using Zinnia.Rule;

    /// <summary>
    /// The basis for all dispatcher types for the spatial targets.
    /// </summary>
    public abstract class Dispatcher : MonoBehaviour
    {
        /// <summary>
        /// Determine which <see cref="SurfaceData"/> sources can interact with this <see cref="Dispatcher"/>.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public RuleContainer SourceValidity { get; set; }

        /// <summary>
        /// Dispatches the Enter command for the given data.
        /// </summary>
        /// <param name="data">The data that has been entered.</param>
        /// <returns>Whether the dispatch was successful.</returns>
        [RequiresBehaviourState]
        public virtual bool DispatchEnter(SurfaceData data)
        {
            if (!IsValidData(data))
            {
                return false;
            }

            return Enter(data);
        }

        /// <summary>
        /// Dispatches the Enter command for the given data.
        /// </summary>
        /// <param name="data">The data that has been entered.</param>
        public virtual void DoDispatchEnter(SurfaceData data)
        {
            DispatchEnter(data);
        }

        /// <summary>
        /// Dispatches the Exit command for the given data.
        /// </summary>
        /// <param name="data">The data that has been exited.</param>
        /// <returns>Whether the dispatch was successful.</returns>
        [RequiresBehaviourState]
        public virtual bool DispatchExit(SurfaceData data)
        {
            if (!IsValidData(data))
            {
                return false;
            }

            return Exit(data);
        }

        /// <summary>
        /// Dispatches the Exit command for the given data.
        /// </summary>
        /// <param name="data">The data that has been exited.</param>
        public virtual void DoDispatchExit(SurfaceData data)
        {
            DispatchExit(data);
        }

        /// <summary>
        /// Dispatches the Select command for the given data.
        /// </summary>
        /// <param name="data">The data that has been selected.</param>
        /// <returns>Whether the dispatch was successful.</returns>
        [RequiresBehaviourState]
        public virtual bool DispatchSelect(SurfaceData data)
        {
            if (!IsValidData(data))
            {
                return false;
            }

            return Select(data);
        }

        /// <summary>
        /// Dispatches the Select command for the given data.
        /// </summary>
        /// <param name="data">The data that has been selected.</param>
        public virtual void DoDispatchSelect(SurfaceData data)
        {
            DispatchSelect(data);
        }

        /// <summary>
        /// Processes the given data as an Enter command on a <see cref="SpatialTarget"/>.
        /// </summary>
        /// <param name="data">The data that has been entered.</param>
        /// <returns>Whether the process was successful.</returns>
        protected abstract bool Enter(SurfaceData data);
        /// <summary>
        /// Processes the given data as an Exit command on a <see cref="SpatialTarget"/>.
        /// </summary>
        /// <param name="data">The data that has been exited.</param>
        /// <returns>Whether the process was successful.</returns>
        protected abstract bool Exit(SurfaceData data);
        /// <summary>
        /// Processes the given data as an Select command on a <see cref="SpatialTarget"/>.
        /// </summary>
        /// <param name="data">The data that has been selected.</param>
        /// <returns>Whether the process was successful.</returns>
        protected abstract bool Select(SurfaceData data);

        /// <summary>
        /// Whether the given data is valid.
        /// </summary>
        /// <param name="data">The data to check.</param>
        /// <returns>Whether the data is valid.</returns>
        protected virtual bool IsValidData(SurfaceData data)
        {
            return data != null && data.Transform != null && data.Transform.gameObject != null && SourceValidity.Accepts(data.Transform.gameObject);
        }
    }
}
