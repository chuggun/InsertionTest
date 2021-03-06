﻿using System;
using System.Linq;

namespace Comparison
{
    public abstract class Provider<T> : IProvider
    {
        private T[] _dataItems;

        public abstract string Name { get; }

        protected Provider(Metering[] meterings)
        {
            _dataItems = CreateDataItems(meterings);
        }

        /// <summary>
        /// Use to create instance-based entities collection
        /// </summary>
        /// <param name="meterings"></param>
        /// <returns></returns>
        protected abstract T[] CreateDataItems(Metering[] meterings);

        public void ParallelIterativeInsertion() => _dataItems.AsParallel().ForAll(p => AddSingle(p));

        public void NonParallelIterativeInsertion() { foreach (var item in _dataItems) AddSingle(item); }

        /// <summary>
        /// Use to add new item in both synchronous and asynchronous operations
        /// </summary>
        /// <param name="item"></param>
        protected abstract void AddSingle(T item);

        public void BulkInsertion()
        {
            AddMultiple(_dataItems);
        }

        /// <summary>
        /// Use with instance-based methods for adding range of objects
        /// </summary>
        /// <param name="dataItems"></param>
        protected abstract void AddMultiple(T[] dataItems);

        public abstract void ClearSource();
    }

    public struct Metering
    {
        public int IDOBJECT { get; set; }
        public int IDTYPE_OBJECT { get; set; }
        public DateTime TIME_BEGIN { get; set; }
        public DateTime TIME_END { get; set; }
        public int IDOBJECT_AGGREGATE { get; set; }
        public int IDOBJECT_AVERAGE { get; set; }
        public int? STATUS { get; set; }
        public double VALUE_METERING { get; set; }
    }
}
