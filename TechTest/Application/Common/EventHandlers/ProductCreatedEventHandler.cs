using Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventHandler> _logger;
        public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            //We can also publish a message to a message bus for other service/app that are interested in this event to subscribe/listern to it
            // or send an email notification
            //or log the notification

            _logger.LogInformation("Product : {ProductName} was created.", notification.Item.Name);

            return Task.CompletedTask;
        }

    }
}
