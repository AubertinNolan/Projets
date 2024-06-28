local Lander = {}
Lander.x = 0 -- position du vaisseau sur l'axe X (horizontal)
Lander.y = 0 -- position du vaisseau sur l'axe Y (vertical)
Lander.angle = 270 -- angle vers lequel pointe le vaisseau (0 degré incline la pointe du vaisseau vers la droite)
Lander.vx = 0 -- vitesse du vaisseau sur l'axe X
Lander.vy = 0 -- vitesse du vaisseau sur l'axe Y
Lander.speed = 1 -- vitesse du vaiseau lorsque l'on va appuyer sur la touche Z ou flèche du haut
Lander.EngineOn = false -- Affichage des flammes du moteur pour indiquer que l'on bouge (faux par défaut)
Lander.imgShip = love.graphics.newImage("images/ship.png") -- On va chercher l'image du vaisseau dans les dossiers
Lander.imgEngine = love.graphics.newImage("images/engine.png") -- On va chercher l'image du moteur dans les dossiers

function love.load() -- 1ère fonction qui se lance quand on ouvre le jeu
    largeur = love.graphics.getWidth() -- on prend la largeur de l'écran dans une variable pour faire des calculs de position
    hauteur = love.graphics.getHeight() -- on prend la hauteur de l'écran dans une variable pour faire des calculs de position

    Lander.x = largeur / 2 -- on positionne le vaisseau au milieu de l'écran
    Lander.y = hauteur / 2 -- on positionne le vaisseau au milieu de l'écran
end

function love.update(dt) -- fonction qui va s'éxecuter 60 fois par secondes (deltatime) pour mettre a jour le jeu
    if love.keyboard.isDown("right") or love.keyboard.isDown("d") then -- si la flèche de droite ou la touche d est enfoncée alors
        Lander.angle = Lander.angle + (90 * dt) -- le vaisseau va tourner a 90 degré en 1 seconde vers la droite
        if Lander.angle > 360 then -- Sans ce test la valeur Lander.angle peut atteindre -1000 ou 1000 degré
            Lander.angle = 0 -- on réinitialise l'angle du vaisseau a 0 pour faciliter les calculs que l'on pourrait faire avec
        end
    end

    if love.keyboard.isDown("left") or love.keyboard.isDown("q") then -- si la flèche de gauche ou la touche q est enfoncée alors
        Lander.angle = Lander.angle - (90 * dt) -- le vaisseau va tourner a 90 degré en 1 seconde vers la gauche
        if Lander.angle < 0 then -- Sans ce test la valeur Lander.angle peut atteindre -1000 ou 1000 degré
            Lander.angle = 360 -- on réinitialise l'angle du vaisseau a 0 pour faciliter les calculs que l'on pourrait faire avec
        end
    end

    if love.keyboard.isDown("up") or love.keyboard.isDown("z") then -- si la flèche du haut ou la touche z est enfoncée alors
        Lander.EngineOn = true -- on veut avancer donc le moteur s'active

        local angle_radian = math.rad(Lander.angle) -- Sans le math.rad un angle de 90° n'est pas exactement a 90°
        local force_x = math.cos(angle_radian) * (Lander.speed * dt) --
        local force_y = math.sin(angle_radian) * (Lander.speed * dt) --
        Lander.vx = Lander.vx + force_x -- on ajoute la force x a la vitesse x du vaisseau pour qu'il puisse voler en prenant la vélocité en compte
        Lander.vy = Lander.vy + force_y -- on ajoute la force y a la vitesse y du vaisseau pour qu'il puisse voler en prenant la vélocité en compte
        if math.abs(Lander.vx) > 1 then -- On donne une valeur maximale a la vitesse x du vaisseau pour qu'il n'aille pas trop vite | math.abs permet de ne pas tenir compte des valeurs négatives
            if Lander.vx > 0 then --
                Lander.vx = 1 --
            else
                Lander.vx = -1 --
            end
        end

        if math.abs(Lander.vy) > 1 then -- On donne une valeur maximale a la vitesse y du vaisseau pour qu'il n'aille pas trop vite |
            if Lander.vy > 0 then
                Lander.vy = 1
            else
                Lander.vy = -1
            end
        end
    else
        Lander.EngineOn = false -- Si on arrête d'appuyer sur le bouton avancer alors le moteur s'arrête
    end

    Lander.vy = Lander.vy + (0.4 * dt) -- gravité imposée au vaisseau

    if love.keyboard.isDown("r") then -- si la touche r est enfoncée alors on réinitialise les valeurs du vaisseau par défaut
        Lander.x = largeur / 2
        Lander.y = hauteur / 2
        Lander.vx = 0
        Lander.vy = 0
        Lander.angle = 270
    end

    Lander.x = Lander.x + Lander.vx -- on ajoute la vitesse x du vaisseau a sa position dans l'espace pour qu'il puisse bouger sur l'écran
    Lander.y = Lander.y + Lander.vy -- on ajoute la vitesse y du vaisseau a sa position dans l'espace pour qu'il puisse bouger sur l'écran
    --[[if Lander.angle < -360 or Lander.angle > 360 then
        Lander.angle = 0
    end ]]
end

function love.keypressed(key)
    if key == "f1" then
        debugMode = true
    end
end
function love.draw() -- Fonction qui efface et réaffiche tous les pixels de l'écran suivant le taux de rafraichissement de l'écran
    love.graphics.draw( -- méthode qui permet de dessiner sur l'écran (image, particule,vidéo,...)
        Lander.imgShip, -- 1er paramètre : on affiche ce que l'on veut (l'image du vaisseau)
        Lander.x, -- 2ème paramètre : on lui indique sa position x
        Lander.y, -- 3ème paramètre : on lui indique sa position y
        math.rad(Lander.angle), -- 4eme paramètre : on lui indique son orientation
        1, -- 5eme paramètre : on lui indique sa taille X par rapport a l'image d'origine (1 par défaut)
        1, -- 6eme paramètre : on lui indique sa taille Y par rapport a l'image d'origine (1 par défaut)
        Lander.imgShip:getWidth() / 2, -- 7eme paramètre : on lui indique a quel point l'image doit être décalée par rapport a son point d'origine (qui est en haut a droite de l'image)
        Lander.imgShip:getHeight() / 2 -- 8eme paramètre : on lui indique a quel point l'image doit être décalée par rapport a son point d'origine (qui est en haut a droite de l'image)
    )

    if Lander.EngineOn == true then -- S'active uniquement quand le joueur appuie sur avancer
        love.graphics.draw(
            Lander.imgEngine,
            Lander.x,
            Lander.y,
            math.rad(Lander.angle),
            1,
            1,
            Lander.imgEngine:getWidth() / 2,
            Lander.imgEngine:getHeight() / 2
        )
    end

    if debugMode == true then
        local sDebug = "" -- on crée une zone de texte pour débuguer le jeu
        sDebug = sDebug .. "Angle :" .. tostring(Lander.angle)
        sDebug = sDebug .. "\nVitesse x :" .. tostring(Lander.vx)
        sDebug = sDebug .. "\nVitesse y :" .. tostring(Lander.vy)
        love.graphics.print(sDebug, 0, 0)
    end
end
