using FlatBiblio;

#region HTML

const string htmlDebut = """
    <!doctype html>
    <html lang='fr'>
        <head>
            <meta charset='utf-8'><meta name='viewport' content='width=device-width, initial-scale=1'>
            <title>Bibliothèque</title><link href='https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3' crossorigin='anonymous'><meta name='theme-color' content='#7952b3'>
            <style>
                .bd-placeholder-img {{
                    font-size: 1.125rem; 
                    text-anchor: middle; 
                    -webkit-user-select: none; 
                    -moz-user-select: none; 
                    user-select: none; 
                }}
                @media (min-width: 768px) {{
                    .bd-placeholder-img-lg {{ 
                        font-size: 3.5rem; 
                     }}
                }}
            </style>
        </head>
        <body>
            <header>
                <div class='collapse bg-dark' id='navbarHeader'>
                    <div class='container'>
                        <div class='row'>
                            <div class='col-sm-8 col-md-7 py-4'>
                                <h4 class='text-white'>A propos</h4>
                                <p class='text-muted'>N° d'emprunteur : {0}</p>
                            </div>
                            <div class='col-sm-4 offset-md-1 py-4'>
                                <h4 class='text-white'>Contacts</h4>
                                <ul class='list-unstyled'>
                                    <li><a href='#' class='text-white'>Nous écrire</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class='navbar navbar-dark bg-dark shadow-sm'>
                    <div class='container'>
                        <a href='index.html' class='navbar-brand d-flex align-items-center'><strong>{1} {2}</strong></a>
                        <button class='navbar-toggler' type='button' data-bs-toggle='collapse' data-bs-target='#navbarHeader' aria-controls='navbarHeader' aria-expanded='false' aria-label='Toggle navigation'><span class='navbar-toggler-icon'></span></button>
                    </div>
                </div>
            </header>
            <main>
                <section class='py-5 text-center container'>
                    <div class='row py-lg-5'>
                        <div class='col-lg-6 col-md-8 mx-auto'>
                            <h1 class='fw-light'>Emprunts en cours</h1>
                            <p class='lead text-muted'>Voici la liste des livres que vous avez empruntés.</p>
                        </div>
                    </div>
                </section>
                <div class='album py-5 bg-light'>
                    <div class='container'>
                        <div class='row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3'>
    """;
const string htmlLivre = """
                            <!-- Un livre -->
                            <div class='col'>
                                <div class='card shadow-sm'>
                                    <img class='card-img-top' src='img/{0}.jpg' alt='Card image cap'>
                                    <div class='card-body'>
                                        <h5 class='card-title'>{1}</h5>
                                        <p class='card-text'>
                                            This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- Fin livre -->
    """;
const string htmlFin = """
                        </div>
                    </div>
                </div>
            </main>
            <footer class='text-muted py-5'>
                <div class='container'>
                    <p class='float-end mb-1'><a href='#'>Retour en haut</a></p>
                    <p class='mb-1'>Album example is &copy; Bootstrap, but please download and customize it for yourself!</p>
                    <p class='mb-0'>New to Bootstrap? <a href='/'>Visit the homepage</a> or read our <a href='/docs/5.1/getting-started/introduction/'>getting started guide</a>.</p>
                </div>
            </footer>"
            <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js' integrity='sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p' crossorigin='anonymous'></script>"
        </body>
    </html>
    """;
#endregion

Dictionary<string, Livre> catalogue = new ();

for(var vide = false; !vide; )
{
    var saisie = Console.ReadLine();

    var parties = saisie?.Split("\t");

    if (string.IsNullOrEmpty(saisie))
    {
        vide = true;
    }
    else if (parties?.Length == 2)
    {
        var isbn = parties[0];
        var titre = parties[1];
        Livre livre = new Livre(isbn, titre);

        catalogue[isbn] = livre;
    }
    else
    {
        Console.Error.WriteLine("Mauvais format");
    }
}

var nom     = Console.ReadLine();
var prenom  = Console.ReadLine();
var ville   = Console.ReadLine();
var numero  = Console.ReadLine();
var emprunteurCourant = new Emprunteur(numero ?? "?", prenom ?? "?", nom ?? "?", ville ?? "?");

Console.ReadLine(); 

for(var vide = false; !vide; )
{
    var isbn = Console.ReadLine();

    if (string.IsNullOrEmpty(isbn))
    {
        vide = true;
    }
    else if (catalogue.ContainsKey(isbn))
    {
        emprunteurCourant.Emprunter(catalogue[isbn]);
    }
    else
    {
        Console.Error.WriteLine($"Pas de livre avec l'isbn {isbn}.");
    }
}

Console.WriteLine(htmlDebut, emprunteurCourant.Numero, emprunteurCourant.Prenom, emprunteurCourant.Nom);
foreach (var livre in emprunteurCourant.Livres)
{
    Console.WriteLine(htmlLivre, livre.Isbn, livre.Titre);
}
Console.WriteLine(htmlFin);

