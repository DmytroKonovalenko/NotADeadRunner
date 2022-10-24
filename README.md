# NotADeadRunner

![Image alt](https://play-lh.googleusercontent.com/ZueExTGC6FLcLIdBHuozjbzjp4nVf28sc3ftuKw7XmlmmmkkKHY2xbhfGf8ryRiGPTw=w240-h480-rw)
 
 
 This project is a 3D runner with the implementation of resource collection, coin accumulation, game points accrual,recording and preservation of records as well as the main menu and animations of the main character.
 


## Scoring

![image](https://play-lh.googleusercontent.com/27QYal797jvzTZk14DnkIFRoSAGdKMgVM_n3-9y_LMrNzOVS5ey6NYqAK08GtUgll3M=w2560-h1440-rw)

```C#
    [SerializeField] private Transform player;
    [SerializeField] public Text scoreText;
    private int totalScore;
    public int scoreMultiplier;
    private void FixedUpdate()
    {
        totalScore += scoreMultiplier;
        scoreText.text = totalScore.ToString();
    }
```

## Animations

Running, jumping and rolling animations were implemented.

![image](https://play-lh.googleusercontent.com/Umr8E8P9Xl56hA2FVD-VBAwSEBiJ9Fi5qRLJaBrZBSTUv6oaIkIcEAUz7yx22_XcJ1k=w2560-h1440-rw)
![image](https://play-lh.googleusercontent.com/bgdd9Z0RyLSHNUWlvKUZ0iNm3tJx6v5_Z0OfP0zKsnTzHQBqNiJnQLZw42bAF_rzpGM=w2560-h1440-rw)


## Main menu

![image](https://play-lh.googleusercontent.com/3Pi0LtHGrd3J_mZoIXnPgHuSuJJKDH0-4ydozim3Lx0hJoMhLI8INet8ermUoXVzjFI=w2560-h1440-rw)

## Recording and preservation of records
 
 ![image](https://play-lh.googleusercontent.com/_jwZ6ZV2ihHUYrFYuuk4hAlg-oWgRMxVNFiHmK4hr01Gy12AFIBKa6yayoOOdZbLwJWS=w2560-h1440-rw)
 
 ___
 
 This project is posted on the trading platform via the [link](https://play.google.com/store/apps/details?id=com.RagsToRichesCompany.NotaDeadRunner&hl=uk&gl=US).
