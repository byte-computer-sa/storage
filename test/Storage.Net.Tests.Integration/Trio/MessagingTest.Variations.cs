﻿using System;
using Amazon;
using Storage.Net.Blobs;
using Storage.Net.Messaging;
using Xunit;

namespace Storage.Net.Tests.Integration.Messaging
{

   #region [ Azure Storage Queue ]

   public class AzureStorageQueueFixture : MessagingFixture
   {
      protected override IMessenger CreateMessenger(ITestSettings settings) =>
         StorageFactory.Messages.AzureStorageQueue(
            settings.AzureStorageName,
            settings.AzureStorageKey);
   }

   public class AzureStorageQueueTest : MessagingTest, IClassFixture<AzureStorageQueueFixture>
   {
      public AzureStorageQueueTest(AzureStorageQueueFixture fixture) : base(fixture)
      {
      }
   }

   #endregion

   #region [ In-Memory ]

   public class InMemoryFixture : MessagingFixture
   {
      protected override IMessenger CreateMessenger(ITestSettings settings)
      {
         return StorageFactory.Messages.InMemory("test");
      }
   }

   public class InMemoryTest : MessagingTest, IClassFixture<InMemoryFixture>
   {
      public InMemoryTest(InMemoryFixture fixture) : base(fixture)
      {
      }
   }

   #endregion

   #region [ Disk ]

   public class DiskFixture : MessagingFixture
   {
      protected override IMessenger CreateMessenger(ITestSettings settings)
      {
         return StorageFactory.Messages.Disk(_testDir);
      }
   }

   public class DiskTest : MessagingTest, IClassFixture<DiskFixture>
   {
      public DiskTest(DiskFixture fixture) : base(fixture)
      {
      }
   }

   #endregion

}