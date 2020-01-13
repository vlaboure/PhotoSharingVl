using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace PhotoSharingVl.Models
{
    //classe qui fait l'interface entre le projet et la pseudo base
    //pour ce projet les bases sont remplacées par des listes
    public class PhotoSharingInitializer:DropCreateDatabaseAlways<PhotoSharedContext>
    {
        private byte[] GetFileBytes(string path)
        {
            //création de l'objet pour stocker le fichier initialisé avec le chemin du fichier
            FileStream fileOnDisk=new FileStream(HttpRuntime.AppDomainAppPath+path,FileMode.Open);
            //tableau utilisé pour le return
            byte[] fileBytes;
            //using pour gerer les erreurs eventuelles
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            // on retourne le tableau de byte du fichier
            return fileBytes;
        }

        //Constructeur override
        protected override void Seed(PhotoSharedContext context)
        {
            base.Seed(context);
            const int max = 7;
            //on remplit la liste de photos+
            Random Aleat = new Random();

            var photos = new List<Photo>
            {
                new Photo
                {
                    Title="Mûres",
                    Description="L'automne arrive",
                    UserName="Vincent",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\blackberries.jpg"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Cote",
                    Description="La belle mer du nord",
                    UserName="Momo",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\coastalview.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Irlande",
                    Description="Les paysages de l'irlande...",
                    UserName="Thomas",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\headland.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Petit pinou",
                    Description="Il est malheureux le petit pînou",
                    UserName="Vincent",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\MonCoucou.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Cailloux",
                    Description="On casse des briques...",
                    UserName="Dalton",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\pebbles.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Il boude",
                    Description="Pinou a un pet qui coince",
                    UserName="Vincent",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\pinou1.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="L'aine",
                    Description="Froid humide mais beau",
                    UserName="Michel",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\pontoon.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Flaques",
                    Description="Floc Floc...",
                    UserName="Rain Man",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\ripples.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Rivière",
                    Description="On plonge ??",
                    UserName="Fish Man",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\rockpool.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                },
                new Photo
                {
                    Title="Orée du bois",
                    Description="La fraicheur de la forêt en été...",
                    UserName="Dorothé",
                    ImageMimeType="image/jpeg",
                    PhotoFile=GetFileBytes("\\SamplePhotos\\track.JPG"),
                    DateCreation=DateTime.Today.AddDays(-Aleat.Next(1,max))
                }
            };
            //remplir le Dbcontext avec chk valeur de la list de photos
            //chk photo de la list DbContext de  cotext est renseignée
            photos.ForEach(p => context.Photos.Add(p));
            context.SaveChanges();    
            // puis les commentaires 
            var comments = new List<Comment>
            {
                new Comment {
                    PhotoID = 1,
                    UserName = "JamieStark",
                    Subject = "Sample Comment 1",
                    Body = "This is the first sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 1,
                    UserName = "JimCorbin",
                    Subject = "Sample Comment 2",
                    Body = "This is the second sample comment in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 4,
                    UserName = "RobinMaster",
                    Subject = "Sample Comment 4",
                    Body = "Pilou bilou le petit coucou"
                },
                new Comment {
                    PhotoID = 3,
                    UserName = "RogerLengel",
                    Subject = "Sample Comment 3",
                    Body = "This is the third sample photo in the Adventure Works photo application"
                },
                new Comment {
                    PhotoID = 4,
                    UserName = "vincent",
                    Subject = "Sample Comment 4",
                    Body = "Ce jout là je lui en ai mis une..."
                },
            };
            //remplir le Dbcontext avec chk valeur de la list de comment
            //chk photo de la list DbContext de  cotext est renseignée
            comments.ForEach(c => context.Comments.Add(c));
            context.SaveChanges();
        }
    }
}