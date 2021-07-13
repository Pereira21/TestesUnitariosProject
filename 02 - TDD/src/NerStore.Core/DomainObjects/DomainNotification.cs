using MediatR;
using NerdStore.Core.Messages;
using System;

namespace NerdStore.Core.DomainObjects
{
    public class DomainNotification : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
