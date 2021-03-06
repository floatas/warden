﻿using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Warden.Core.Exceptions
{
    [Serializable]
    public class WardenException : Exception
    {
        public WardenException()
        {
        }

        public WardenException(string message)
            : base(message)
        {
        }

        public WardenException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected WardenException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResourceReferenceProperty = info.GetString(WardenExceptionStrings.ResourceReferenceProperty);
        }

        public string ResourceReferenceProperty { get; set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue(WardenExceptionStrings.ResourceReferenceProperty, ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}
