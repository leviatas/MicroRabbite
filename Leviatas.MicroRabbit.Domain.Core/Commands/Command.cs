﻿using Leviatas.MicroRabbit.Domain.Core.Events;

namespace Leviatas.MicroRabbit.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
