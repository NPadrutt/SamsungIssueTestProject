using System.Data.Common;
using SamsungIssueTestProject.DataAccess;
using SamsungIssueTestProject.Foundation.Interfaces;
using Microsoft.EntityFrameworkCore;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace SamsungIssueTestProject.Business
{
    /// <summary>
    ///     Helper to start the app on all plattforms.
    /// </summary>
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private const string CREATE_CHANGES =
            "CREATE TABLE IF NOT EXISTS \"Changes\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_Changes\" PRIMARY KEY AUTOINCREMENT, \"ChangeText\" TEXT, \"ContactName\" TEXT , \"Timestamp\" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00')";

        private const string CREATE_CONTACT_ADDRESSES =
            "CREATE TABLE IF NOT EXISTS \"ContactAddresss\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_ContactAddresss\" PRIMARY KEY AUTOINCREMENT, \"City\" TEXT, \"ContactId\" INTEGER NOT NULL, \"Country\" TEXT, \"IdAddressbook\" INTEGER NOT NULL, \"IdService\" INTEGER NOT NULL, \"InfoType\" INTEGER NOT NULL, \"Postcode\" TEXT, \"Street\" TEXT, \"HasUnsavedChanges\" INTEGER NOT NULL DEFAULT 0, CONSTRAINT \"FK_ContactAddresss_Contacts_ContactId\" FOREIGN KEY (\"ContactId\") REFERENCES \"Contacts\" (\"Id\") ON DELETE CASCADE )";
        private const string CREATE_CONTACT_EVENTS =
            "CREATE TABLE IF NOT EXISTS \"ContactEvents\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_ContactEvents\" PRIMARY KEY AUTOINCREMENT, \"ContactId\" INTEGER NOT NULL, \"IdAddressbook\" INTEGER NOT NULL, \"IdService\" INTEGER NOT NULL, \"InfoType\" INTEGER NOT NULL, \"Name\" TEXT, \"Periodicity\" INTEGER NOT NULL, \"Start\" TEXT NOT NULL, \"HasUnsavedChanges\" INTEGER NOT NULL DEFAULT 0, CONSTRAINT \"FK_ContactEvents_Contacts_ContactId\" FOREIGN KEY (\"ContactId\") REFERENCES \"Contacts\" (\"Id\") ON DELETE CASCADE )";
        private const string CREATE_CONTACT_INFOS =
            "CREATE TABLE IF NOT EXISTS \"ContactInfos\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_ContactInfos\" PRIMARY KEY AUTOINCREMENT, \"ContactId\" INTEGER NOT NULL, \"IdAddressbook\" INTEGER NOT NULL, \"IdService\" INTEGER NOT NULL, \"Info\" TEXT, \"InfoType\" INTEGER NOT NULL, \"HasUnsavedChanges\" INTEGER NOT NULL DEFAULT 0, CONSTRAINT \"FK_ContactInfos_Contacts_ContactId\" FOREIGN KEY (\"ContactId\") REFERENCES \"Contacts\" (\"Id\") ON DELETE CASCADE )";
        private const string CREATE_CONTACTS =
            "CREATE TABLE IF NOT EXISTS \"Contacts\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_Contacts\" PRIMARY KEY AUTOINCREMENT, \"IdAddressbook\" INTEGER NOT NULL, \"IdService\" INTEGER NOT NULL, \"Image\" BLOB, \"IsAllowedToReceiveMyInfos\" INTEGER NOT NULL, \"IsMe\" INTEGER NOT NULL, \"MiddleName\" TEXT, \"Name\" TEXT, \"Prename\" TEXT, \"UserId\" INTEGER NOT NULL, \"HasUnsavedChanges\" INTEGER NOT NULL DEFAULT 0, CONSTRAINT \"FK_Contacts_Users_UserId\" FOREIGN KEY (\"UserId\") REFERENCES \"Users\" (\"Id\") ON DELETE CASCADE )";

        private const string CREATE_REQUESTS =
            "CREATE TABLE IF NOT EXISTS \"Requests\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_Requests\" PRIMARY KEY AUTOINCREMENT, \"IsEstablished\" INTEGER NOT NULL, \"UserFromNumber\" TEXT, \"UserToNumber\" TEXT , \"Displayname\" TEXT)";

        private const string CREATE_USERS =
            "CREATE TABLE IF NOT EXISTS \"Users\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_Users\" PRIMARY KEY AUTOINCREMENT, \"IdService\" INTEGER NOT NULL, \"PhoneNumber\" TEXT )";

        private const string CREATE_EF_MIGRATIONS =
            "CREATE TABLE IF NOT EXISTS \"__EFMigrationsHistory\" ( \"MigrationId\" TEXT NOT NULL CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY, \"ProductVersion\" TEXT NOT NULL )";


        /// <summary>
        ///     Execute code on start up.
        /// </summary>
        /// <param name="hint">parameter for the launch of the app.</param>
        public async void Start(object hint = null)
        {
            try
            {
                FadContext.DataBasePath = Mvx.Resolve<ISqlite>().DbPath;
                using (var db = new FadContext())
                {
                    await db.Database.MigrateAsync();
                }
            } 
            catch (DbException e)
            { 
                /*
                 * THIS IS A WORKAROUND TO MAKE IT WORK ON SAMSUNG DEVICES
                using (var db = new FadContext())
                {
                    db.Database.ExecuteSqlCommand(CREATE_CHANGES);
                    db.Database.ExecuteSqlCommand(CREATE_CONTACT_ADDRESSES);
                    db.Database.ExecuteSqlCommand(CREATE_CONTACT_EVENTS);
                    db.Database.ExecuteSqlCommand(CREATE_CONTACT_INFOS);
                    db.Database.ExecuteSqlCommand(CREATE_CONTACTS);
                    db.Database.ExecuteSqlCommand(CREATE_REQUESTS);
                    db.Database.ExecuteSqlCommand(CREATE_USERS);
                    db.Database.ExecuteSqlCommand(CREATE_EF_MIGRATIONS);
                }
                Console.WriteLine(e);
                */
            }
        }
    }
}