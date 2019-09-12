﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Storage.Net.Messaging
{
   /// <summary>
   /// Messenger interface
   /// </summary>
   public interface IMessenger : IDisposable
   {
      /// <summary>
      /// List available channels
      /// </summary>
      /// <returns></returns>
      Task<IReadOnlyCollection<string>> ListChannelsAsync(CancellationToken cancellationToken = default);

      /// <summary>
      /// Gets message count in a channel.
      /// </summary>
      /// <param name="channelName"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
      Task<long> GetMessageCountAsync(string channelName, CancellationToken cancellationToken = default);

      /// <summary>
      /// Send messages to a channel
      /// </summary>
      /// <param name="channelName"></param>
      /// <param name="messages"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
      Task SendAsync(string channelName, IEnumerable<QueueMessage> messages, CancellationToken cancellationToken = default);

      /// <summary>
      /// Receive messages from a channel
      /// </summary>
      /// <param name="channelName"></param>
      /// <param name="count"></param>
      /// <param name="visibility"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
      Task<IReadOnlyCollection<QueueMessage>> ReceiveAsync(
         string channelName,
         int count = 100,
         TimeSpan? visibility = null,
         CancellationToken cancellationToken = default);

      /// <summary>
      /// Peek messages in a channel
      /// </summary>
      /// <param name="channelName"></param>
      /// <param name="count"></param>
      /// <param name="cancellationToken"></param>
      /// <returns></returns>
      Task<IReadOnlyCollection<QueueMessage>> PeekAsync(
         string channelName,
         int count = 100,
         CancellationToken cancellationToken = default);
   }
}
