﻿namespace Zinnia.Data.Type.Transformation.Conversion
{
    using System;
    using UnityEngine.Events;

    /// <summary>
    /// Transforms a boolean value to the equivalent float value.
    /// </summary>
    /// <example>
    /// false = 0f
    /// true = 1f
    /// </example>
    public class BooleanToFloat : Transformer<bool, float, BooleanToFloat.UnityEvent>
    {
        /// <summary>
        /// Defines the event with the transformed <see cref="float"/> value.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<float> { }

        /// <summary>
        /// Transforms the given input <see cref="bool"/> to the <see cref="float"/> equivalent value.
        /// </summary>
        /// <param name="input">The value to transform.</param>
        /// <returns>The transformed value.</returns>
        protected override float Process(bool input)
        {
            return input ? 1f : 0f;
        }
    }
}