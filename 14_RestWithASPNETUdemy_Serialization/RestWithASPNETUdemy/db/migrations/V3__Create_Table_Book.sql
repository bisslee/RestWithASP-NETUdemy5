CREATE TABLE IF NOT EXISTS `book` (
  `id` bigint NOT NULL AUTO_INCREMENT,  
  `title` varchar(120)NOT NULL,
  `author` varchar(120) NOT NULL,
  `isbn` varchar(60) NOT NULL,
  `edition` varchar(30) NOT NULL,
  `price` decimal NOT NULL,
  `launch_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) 