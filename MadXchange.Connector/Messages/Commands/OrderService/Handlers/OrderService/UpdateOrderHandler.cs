﻿using MadXchange.Common.Handlers;
using MadXchange.Common.Types;
using MadXchange.Connector.Interfaces;
using MadXchange.Connector.Messages.Commands;
using MadXchange.Exchange.Domain.Models;
using MadXchange.Exchange.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MadXchange.Exchange.Messages.Commands.Handlers
{
    public class UpdateOrderHandler : ICommandHandler<UpdateOrder>
    {

        //private readonly IAsyncRepository<long> _orderRepository;
        private readonly IExchangeRequestServiceClient _orderClient;
        private readonly ILogger _logger;
        public UpdateOrderHandler(IExchangeRequestServiceClient orderClient, ILogger<UpdateOrderHandler> logger) 
        {
            _orderClient = orderClient;
            //_orderRepository = orderRepository;
            _logger = logger;
        
        }
        public async Task HandleAsync(UpdateOrder order) 
        {
            var update = await _orderClient.UpdateOrderAsync(order);
            if (update is null)
            {
                _logger.LogError($"{order.OrderId}");
                throw new System.Exception("order update failed");
            }
            else 
            {
                if(update.OrdStatus != OrderStatus.REJECTED) 
                {
                
                }
            }
        }
    }
}