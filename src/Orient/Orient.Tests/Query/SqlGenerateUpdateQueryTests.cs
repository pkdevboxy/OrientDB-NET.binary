﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orient.Client;

namespace Orient.Tests.Query
{
    [TestClass]
    public class SqlGenerateUpdateQueryTests
    {
        [TestMethod]
        public void ShouldGenerateUpdateClassFromDocumentQuery()
        {
            ODocument document = new ODocument();
            document.OClassName = "TestVertexClass";
            document
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .ToString();

            string query =
                "UPDATE TestVertexClass " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateClassQuery()
        {
            ODocument document = new ODocument()
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .Class("TestVertexClass")
                .ToString();

            string query =
                "UPDATE TestVertexClass " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateClusterQuery()
        {
            ODocument document = new ODocument()
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .Cluster("TestCluster")
                .ToString();

            string query =
                "UPDATE cluster:TestCluster " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRecordFromDocumentQuery()
        {
            ODocument document = new ODocument();
            document.ORID = new ORID(8, 0);
            document
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRecordQuery()
        {
            ODocument document = new ODocument()
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .Record(new ORID(8, 0))
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRecordFromOridQuery()
        {
            ODocument document = new ODocument()
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Set(document)
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRecordSetDocumentQuery()
        {
            ODocument document = new ODocument()
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Set(document)
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRecordSetQuery()
        {
            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Set("foo", "foo string value")
                .Set("bar", 12345)
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateWhereQuery()
        {
            ODocument document = new ODocument();
            document.ORID = new ORID(8, 0);
            document
                .SetField("foo", "foo string value")
                .SetField("bar", 12345);

            string generatedQuery = new OSqlUpdate()
                .Document(document)
                .Where("foo").Equals("whoa")
                .Or("foo").NotEquals(123)
                .And("foo").Lesser(1)
                .And("foo").LesserEqual(2)
                .And("foo").Greater(3)
                .And("foo").GreaterEqual(4)
                .And("foo").Like("%whoa%")
                .And("foo").IsNull()
                .And("foo").Contains("johny")
                .And("foo").Contains("name", "johny")
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "SET foo = 'foo string value', " +
                "bar = 12345 " +
                "WHERE foo = 'whoa' " +
                "OR foo != 123 " +
                "AND foo < 1 " +
                "AND foo <= 2 " +
                "AND foo > 3 " +
                "AND foo >= 4 " +
                "AND foo LIKE '%whoa%' " +
                "AND foo IS NULL " +
                "AND foo CONTAINS 'johny' " +
                "AND foo CONTAINS (name = 'johny')";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateAddCollectionItemQuery()
        {
            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Add("foo", "foo string value")
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "ADD foo = 'foo string value'";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRemoveFieldsQuery()
        {
            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Remove("foo")
                .Remove("bar")
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "REMOVE foo, bar";

            Assert.AreEqual(generatedQuery, query);
        }

        [TestMethod]
        public void ShouldGenerateUpdateRemoveCollectionItemQuery()
        {
            string generatedQuery = new OSqlUpdate()
                .Record(new ORID(8, 0))
                .Remove("foo", 123)
                .ToString();

            string query =
                "UPDATE #8:0 " +
                "REMOVE foo = 123";

            Assert.AreEqual(generatedQuery, query);
        }
    }
}
