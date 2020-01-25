using System;
using System.Web.Routing;
using System.Web.Mvc;
using PhotoSharingTests.Doubles;
using System.Text;
using System.Collections.Generic;
using PhotoSharingVl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PhotoSharingTests
{
    /// <summary>
    /// Description résumée pour RoutingTests
    /// </summary>
    [TestClass]
    public class RoutingTests
    {
        public RoutingTests()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_Default_Route_ControllerOnly()
        {
            var context = new FakeHttpContextForRouting(requestUrl: "~/ControllerName");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            RouteData routeData = routes.GetRouteData(context);
            Assert.IsNotNull(routeData);
            Assert.AreEqual("ControllerName", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);

        }
        [TestMethod]
        public void Test_Photo_Route_With_PhotoId()
        {
            var context = new FakeHttpContextForRouting(requestUrl:"~/photo/2");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            var routeData = routes.GetRouteData(context);
            Assert.IsNotNull(routeData);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("Display", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }
        public void Test_Photo_Title_Route()
        {
            var context = new FakeHttpContextForRouting(requestUrl:"~/photo/title/my%20title");
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            var routeData = routes.GetRouteData(context);
            Assert.AreEqual("Photo", routeData.Values["controller"]);
            Assert.AreEqual("DisplayByTitle", routeData.Values["action"]);
            Assert.AreEqual("my%20title", routeData.Values["title"]);
        }

    }
}
