﻿using System;
using System.Collections.Generic;
using Unity.Container;

namespace Unity.Storage
{
    /// <summary>
    /// This interface defines a standard pipeline to create multi staged pipelines.
    /// </summary>
    /// <typeparam name="TStageEnum">The stage enum</typeparam>
    /// <typeparam name="TPipeline">Type of pipeline to build</typeparam>
    public interface IStagedFactoryChain<TPipeline, in TStageEnum> :
                     IEnumerable<Factory<TPipeline, TPipeline>> 
    {
        /// <summary>
        /// Signals that chain has been changed
        /// </summary>
        event EventHandler<EventArgs> Invalidated;

        /// <summary>
        /// Adds a factory to the chain at a particular stage.
        /// </summary>
        /// <param name="factory">The factory to add to the chain.</param>
        /// <param name="stage">The stage to add the strategy.</param>
        void Add(Factory<TPipeline, TPipeline> factory, TStageEnum stage);

        /// <summary>
        /// Removes the first occurrence of a specific object from the chain
        /// </summary>
        /// <param name="item">Factory to remove</param>
        /// <returns></returns>
        bool Remove(Factory<TPipeline, TPipeline> item);

        /// <summary>
        /// Builds the chain into pipeline
        /// </summary>
        /// <returns>Head of the pipeline chain</returns>
        TPipeline BuildPipeline();
    }
}