﻿using System;
using Mixins.Annotations;

namespace Mixins
{
    [Mixin]
    public struct LazyMixin<T>
        where T : class, new()
    {
        [PrimaryProperty]
        public T Value => _value ?? (_value = new T());

        private T _value;

        [Private]
        public void Reset() => _value = null;

        [Private]
        public bool HasValue => _value != null;

        [Private]
        public void Dispose()
        {
            if (_value != null)
            {
                var d = _value as IDisposable;
                d?.Dispose();
                _value = null;
            }
        }
    }
}
