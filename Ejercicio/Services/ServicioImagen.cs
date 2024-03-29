﻿
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Storage;

namespace Ejercicio.Services
{
    public class ServicioImagen : IServicioImagen
    {
        public async Task<string> SubirImagen(Stream archivo,
            string nombre)
        {
            string email = "ma.conforme@itq.edu.ec";
            string clave = "Mayleth.";
            string ruta = "ejercicioclaselibreria.appspot.com";
            string api_key = "AIzaSyBewcrPuNFCArH8xokJKwcVMoOeeYMqkgo";

            var auth = new FirebaseAuthProvider
                (new FirebaseConfig(api_key));
            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
              ruta,
              new FirebaseStorageOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                  ThrowOnCancel = true
              })

               .Child("Fotos_Perfil")
               .Child(nombre)
               .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }


    }
}
