﻿namespace Zinnia.Process.Component
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Collection.List;
    using Zinnia.Extension;
    using Zinnia.Rule;

    /// <summary>
    /// A <see cref="SourceTargetProcessor{TSource, TTarget}"/> that specifically processes a <see cref="GameObject"/>.
    /// </summary>
    public abstract class GameObjectSourceTargetProcessor : SourceTargetProcessor<GameObject, GameObject, GameObjectSourceTargetProcessor.GameObjectUnityEvent>
    {
        /// <summary>
        /// Defines the event with the <see cref="GameObject"/>.
        /// </summary>
        [Serializable]
        public class GameObjectUnityEvent : UnityEvent<GameObject> { }

        #region Processor Settings
        /// <summary>
        /// A <see cref="GameObject"/> collection of sources to apply data from.
        /// </summary>
        [Serialized]
        [field: Header("Entity Settings"), DocumentedByXml]
        public GameObjectObservableList Sources { get; set; }
        /// <summary>
        /// Allows to optionally determine which sources should be processed based on the set rules.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public RuleContainer SourceValidity { get; set; }
        /// <summary>
        /// A <see cref="GameObject"/> collection of targets to apply data to.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public GameObjectObservableList Targets { get; set; }
        /// <summary>
        /// Allows to optionally determine which targets should be processed based on the set rules.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public RuleContainer TargetValidity { get; set; }
        #endregion

        /// <inheritdoc />
        [RequiresBehaviourState]
        public override void Process()
        {
            ApplySourcesToTargets(Sources.NonSubscribableElements, Targets.NonSubscribableElements);
        }

        /// <inheritdoc />
        protected override void SetCurrentIndices(int sourceIndex, int targetIndex)
        {
            Sources.CurrentIndex = sourceIndex;
            Targets.CurrentIndex = targetIndex;
        }

        /// <inheritdoc />
        protected override bool IsSourceValid(GameObject source)
        {
            return base.IsSourceValid(source) && SourceValidity.Accepts(source);
        }

        /// <inheritdoc />
        protected override bool IsTargetValid(GameObject target)
        {
            return base.IsTargetValid(target) && TargetValidity.Accepts(target);
        }
    }
}